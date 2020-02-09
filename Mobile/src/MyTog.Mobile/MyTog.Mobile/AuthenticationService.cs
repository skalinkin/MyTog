using System;
using System.Linq;
using Kalinkin.MyTog.Mobile.Domain;
using Kalinkin.MyTog.Mobile.SQLiteComponent;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    public abstract class AuthenticationService
    {
        protected ITinyMessengerHub _hub;
        private readonly IAccessTokenLifetimeQuery _query;

        protected AuthenticationService(ITinyMessengerHub hub, IAccessTokenLifetimeQuery query)
        {
            _hub = hub;
            _query = query;

            _hub.Subscribe<StartAuthentication>(obj => AuthenticateAsync());
            _hub.Subscribe<Logout>(obj => LogoutRoutine());
        }

        private void LogoutRoutine()
        {
            Logout();

        }

        public async void AuthenticateAsync()
        {
            _hub.Publish(new StartUpStatus {Sender = this, StatusText = "Authenticating..."});
            var records = await _query.GetItemsAsync();

            if (records.Count == 0)
            {
                Login();
            }
            else
            {
                var last = records.OrderByDescending(r => r.AuthenticationTime).First();
                if (last.AccessTokenExpiration <= DateTime.Now )
                {
                    Login();
                }
                else
                {
                    _hub.Publish(new AuthenticationSuccessful());
                }
            }
        }

        protected abstract void Login();
        protected abstract void Logout();
    }
}