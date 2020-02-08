using Kalinkin.MyTog.Mobile.Domain;
using Kalinkin.MyTog.Mobile.SQLiteComponent;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    public abstract class AuthenticationService
    {
        protected MyTogDatabase _database;
        protected ITinyMessengerHub _hub;

        protected AuthenticationService(ITinyMessengerHub hub, MyTogDatabase database)
        {
            _hub = hub;
            _database = database;
        }

        public async void AuthenticateAsync()
        {
            _hub.Publish(new StartUpStatus {Sender = this, StatusText = "Authenticating..."});
            var records = await _database.GetItemsAsync();

            if (records.Count == 0)
            {
                Login();
            }
        }

        public void LogoutAsync()
        {
            Logout();
        }

        protected abstract void Login();
        protected abstract void Logout();
    }
}