using System.Diagnostics;
using Auth0.OidcClient;
using Kalinkin.MyTog.Mobile;
using Kalinkin.MyTog.Mobile.SQLiteComponent;

namespace MyTog.Mobile.Droid.Auth0Component
{
    public class Auth0AuthenticationService : IAuthenticationService
    {
        private readonly MyTogDatabase _database;

        public Auth0AuthenticationService(MyTogDatabase database)
        {
            _database = database;
        }

        public async void AuthenticateAsync()
        {
            var records = await _database.GetItemsAsync();

            if (records.Count == 0)
            {
                var client = new Auth0Client(new Auth0ClientOptions
                {
                    Domain = "mytog.auth0.com",
                    ClientId = "yKKtP1bkVMtbVXO9dO2y63ShQBirl5ZN"
                });
                var loginResult = await client.LoginAsync();
                if (loginResult.IsError) Debug.Print($"An error occurred during login: {loginResult.Error}");

                if (!loginResult.IsError)
                {
                    Debug.WriteLine($"id_token: {loginResult.IdentityToken}");
                    Debug.WriteLine($"access_token: {loginResult.AccessToken}");
                }

                if (!loginResult.IsError)
                {
                    Debug.WriteLine($"name: {loginResult.User.FindFirst(c => c.Type == "name")?.Value}");
                    Debug.WriteLine($"email: {loginResult.User.FindFirst(c => c.Type == "email")?.Value}");
                }

                if (!loginResult.IsError)
                    foreach (var claim in loginResult.User.Claims)
                        Debug.WriteLine($"{claim.Type} = {claim.Value}");

                var loginResultRecord = new LoginResult
                {
                    AccessToken = loginResult.AccessToken, IdentityToken = loginResult.IdentityToken
                };
                await _database.SaveItemAsync(loginResultRecord);
            }
        }
    }
}