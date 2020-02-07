using Auth0.OidcClient;
using Kalinkin.MyTog.Mobile;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;

namespace MyTog.Mobile.Droid.Auth0Component
{
    public class Auth0AuthenticationService : AuthenticationService
    {
        public Auth0AuthenticationService(ITinyMessengerHub messenger)
        {
            _messenger = messenger;
        }

        protected override void Login()
        {
            var client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = "mytog.auth0.com",
                ClientId = "yKKtP1bkVMtbVXO9dO2y63ShQBirl5ZN"
            });

            var result = client.LoginAsync().Result;

            if (result.IsError)
            {
                _messenger.Publish(new AuthenticationFailed {Error = result.Error});
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
            _messenger.Publish(new AuthenticationSuccessful());
        }
    }
}