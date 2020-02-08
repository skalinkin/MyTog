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
        }

        public async void AuthenticateAsync()
        {
            _hub.Publish(new StartUpStatus {Sender = this, StatusText = "Authenticating..."});
            var records = await _query.GetItemsAsync();

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