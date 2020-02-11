using System;
using System.Linq;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    public class AuthenticationService : IApplicationService
    {
        private readonly IPlatformAuthentication _platformAuthentication;
        private readonly IAccessTokenLifetimeQuery _query;
        private readonly IAccessTokenLifetimeStore _store;
        protected ITinyMessengerHub Hub;

        public AuthenticationService(ITinyMessengerHub hub, IPlatformAuthentication platformAuthentication,
            IAccessTokenLifetimeQuery query, IAccessTokenLifetimeStore store)
        {
            Hub = hub;
            _platformAuthentication = platformAuthentication;
            _query = query;
            _store = store;

            Hub.Subscribe<StartAuthenticationCommand>(obj => AuthenticateAsync());
            Hub.Subscribe<LogoutCommand>(obj => LogoutRoutine());
            Hub.Subscribe<GenericTinyMessage<AccessTokenLifetime>>(OnMessage);
        }

        private async void OnMessage(GenericTinyMessage<AccessTokenLifetime> command)
        {
            await _store.AddItem(command.Content);
        }

        private void LogoutRoutine()
        {
            _platformAuthentication.Logout();
            Hub.Publish(new ClearCurrentAccountCommand());
            Hub.Publish(new ClearCurrentApplicationModeCommand());
            Hub.Publish(new LogoutSuccessEvent());
        }

        public async void AuthenticateAsync()
        {
            var records = (await _query.GetItemsAsync()).ToArray();

            if (!records.Any())
            {
                _platformAuthentication.Login();
            }
            else
            {
                var last = records.OrderByDescending(r => r.AuthenticationTime).First();
                if (last.AccessTokenExpiration <= DateTime.Now)
                {
                    _platformAuthentication.Login();
                }
                else
                {
                    Hub.Publish(new AuthenticationSuccessfulEvent());
                }
            }
        }
    }
}