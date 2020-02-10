using System;
using System.Linq;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    public abstract class AuthenticationService
    {
        private readonly IAccessTokenLifetimeQuery _query;
        protected ITinyMessengerHub _hub;

        protected AuthenticationService(ITinyMessengerHub hub, IAccessTokenLifetimeQuery query)
        {
            _hub = hub;
            _query = query;

            _hub.Subscribe<StartAuthenticationCommand>(obj => AuthenticateAsync());
            _hub.Subscribe<LogoutCommand>(obj => LogoutRoutine());
        }

        private void LogoutRoutine()
        {
            Logout();
            _hub.Publish(new ClearCurrentAccountCommand());
        }

        public async void AuthenticateAsync()
        {
            var records = (await _query.GetItemsAsync()).ToArray();

            if (!records.Any())
            {
                Login();
            }
            else
            {
                var last = records.OrderByDescending(r => r.AuthenticationTime).First();
                if (last.AccessTokenExpiration <= DateTime.Now)
                {
                    Login();
                }
                else
                {
                    _hub.Publish(new AuthenticationSuccessfulEvent());
                }
            }
        }

        protected abstract void Login();
        protected abstract void Logout();
    }
}