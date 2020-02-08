using System;
using Auth0.OidcClient;
using IdentityModel.OidcClient.Browser;
using Kalinkin.MyTog.Mobile;
using Kalinkin.MyTog.Mobile.Domain;
using Kalinkin.MyTog.Mobile.SQLiteComponent;
using TinyMessenger;

namespace MyTog.Mobile.Droid.Auth0Component
{
    public class Auth0AuthenticationService : AuthenticationService
    {
        private readonly Func<Auth0Client> _createClient;

        public Auth0AuthenticationService(ITinyMessengerHub hub, Func<Auth0Client> createClient, MyTogDatabase database)
            : base(hub, database)
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

            //entity. = result.AccessToken;
            //entity. = result.AccessTokenExpiration;
            //entity. = result.AuthenticationTime;
            //entity. = result.IdentityToken;
            //entity. = result.RefreshToken;
            //entity. = result.User.Identity.IsAuthenticated;
            //entity. = result.User.Identity.Name;
            //entity. = result.User.Identity.AuthenticationType;
            //entity. = result.User.;
            //entity. = result.AccessToken;
            //entity. = result.AccessToken;
            //entity. = result.AccessToken;
            //entity. = result.AccessToken;
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