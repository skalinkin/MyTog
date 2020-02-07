using Kalinkin.MyTog.Mobile.Domain;
using Kalinkin.MyTog.Mobile.SQLiteComponent;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    public abstract class AuthenticationService
    {
        protected MyTogDatabase _database;
        protected ITinyMessengerHub _messenger;

        public async void AuthenticateAsync()
        {
            _messenger.Publish(new StartUpStatus {Sender = this, StatusText = "Authenticating..."});
            var records = await _database.GetItemsAsync();

            if (records.Count == 0)
            {
                Login();
            }
        }

        protected abstract void Login();
    }
}