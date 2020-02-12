using System;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    internal class CustomerApplicationMode : IApplicationMode
    {
        private readonly Func<CustomerMasterDetailPage> _createMasterDetailPage;
        private readonly ITinyMessengerHub _hub;
        private App _application;

        public CustomerApplicationMode(ITinyMessengerHub hub, Func<CustomerMasterDetailPage> createMasterDetailPage)
        {
            _hub = hub;
            _createMasterDetailPage = createMasterDetailPage;
        }

        public void SetApplication(App application)
        {
            _application = application;
            var applicationMainPage = _createMasterDetailPage();
            _application.InsureMainThread(() => _application.MainPage = applicationMainPage);

            var typeName = GetType().Name;
        }

        public void HandleOnStart()
        {
        }

        public void HandleOnResume()
        {
        }

        public void HandleOnSleep()
        {
        }
    }
}