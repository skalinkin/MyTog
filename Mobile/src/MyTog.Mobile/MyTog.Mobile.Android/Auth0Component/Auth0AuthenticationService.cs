using System;
using Auth0.OidcClient;
using IdentityModel.OidcClient.Browser;
using Kalinkin.MyTog.Mobile;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;

namespace MyTog.Mobile.Droid.Auth0Component
{
    public class Auth0AuthenticationService : AuthenticationService, IApplicationService
    {
        private readonly Func<Auth0Client> _createClient;

        public Auth0AuthenticationService(ITinyMessengerHub hub, Func<Auth0Client> createClient,
            IAccessTokenLifetimeQuery query)
            : base(hub, query)
        {
            _createClient = createClient;
        }

        protected override async void Login()
        {
            var client = _createClient();
            var result = await client.LoginAsync();

            if (result.IsError)
            {
                _hub.Publish(new AuthenticationFailed {Error = result.Error});
                return;
            }

            var entity = new LoginResult();

            var lifetime = new AccessTokenLifetime
            {
                AccessToken = result.AccessToken,
                AccessTokenExpiration = result.AccessTokenExpiration,
                AuthenticationTime = result.AuthenticationTime,
                IdentityToken = result.IdentityToken,
                RefreshToken = result.RefreshToken
            };
            _hub.Publish(new GenericTinyMessage<AccessTokenLifetime>(this, lifetime));

            //entity. = result.User.Identity.IsAuthenticated;
            //entity. = result.User.Identity.Name;
            //entity. = result.User.Identity.AuthenticationType;
            _hub.Publish(new AuthenticationSuccessful());
        }

        protected override async void Logout()
        {
            var client = _createClient();
            var result = await client.LogoutAsync();

            if (result == BrowserResultType.Success)
            {
                _hub.Publish(new LogoutSuccess());
            }
        }
    }
}