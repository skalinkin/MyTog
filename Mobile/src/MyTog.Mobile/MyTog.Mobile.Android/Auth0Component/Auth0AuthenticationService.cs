using System.Diagnostics;
using Auth0.OidcClient;
using Kalinkin.MyTog.Mobile;
using Kalinkin.MyTog.Mobile.SQLiteComponent;
using TinyMessenger;

namespace MyTog.Mobile.Droid.Auth0Component
{
    public class Auth0AuthenticationService : IAuthenticationService
    {
        private readonly MyTogDatabase _database;
        private readonly ITinyMessengerHub _messenger;

        public Auth0AuthenticationService(MyTogDatabase database, ITinyMessengerHub messenger)
        {
            _database = database;
            _messenger = messenger;
        }

        public async void AuthenticateAsync()
        {
            _messenger.Publish(new StartUpStatus {Sender = this, StatusText = "Authenticating..."});
            var records = await _database.GetItemsAsync();

            if (records.Count == 0)
            {
                var client = new Auth0Client(new Auth0ClientOptions
                {
                    Domain = "mytog.auth0.com",
                    ClientId = "yKKtP1bkVMtbVXO9dO2y63ShQBirl5ZN"
                });
                var loginResult = await client.LoginAsync();
                if (loginResult.IsError)
                {
                    Debug.Print($"An error occurred during login: {loginResult.Error}");
                }
                else
                {
                    _messenger.Publish(new StartUpStatus {Sender = this, StatusText = "User Authenticated."});
                    Debug.WriteLine($"id_token: {loginResult.IdentityToken}");
                    Debug.WriteLine($"access_token: {loginResult.AccessToken}");
                    Debug.WriteLine($"name: {loginResult.User.FindFirst(c => c.Type == "name")?.Value}");
                    Debug.WriteLine($"email: {loginResult.User.FindFirst(c => c.Type == "email")?.Value}");
                    foreach (var claim in loginResult.User.Claims)
                    {
                        Debug.WriteLine($"{claim.Type} = {claim.Value}");
                    }

                    var loginResultRecord = new LoginResult
                    {
                        AccessToken = loginResult.AccessToken, IdentityToken = loginResult.IdentityToken
                    };
                    await _database.SaveItemAsync(loginResultRecord);
                }
            }

            _messenger.Publish(new AuthenticationSuccessful());
        }
    }
}