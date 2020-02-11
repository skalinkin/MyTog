using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    internal class BootstrappingApplicationMode:IApplicationMode
    {
        private readonly ITinyMessengerHub _hub;
        private App _application;

        public BootstrappingApplicationMode(ITinyMessengerHub hub)
        {
            _hub = hub;
        }

        public void SetApplication(App App)
        {
            _application = App;
        }

        public void HandleOnStart()
        {
            _hub.Publish(new ApplicationStartedEvent());
        }

        public void HandleOnResume()
        {
            throw new System.NotImplementedException();
        }

        public void HandleOnSleep()
        {
            throw new System.NotImplementedException();
        }
    }
}