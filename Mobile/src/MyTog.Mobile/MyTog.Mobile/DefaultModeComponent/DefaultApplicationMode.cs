using System;
using Kalinkin.MyTog.Mobile.Domain;
using Kalinkin.MyTog.Mobile.Main;
using Kalinkin.MyTog.Mobile.StartingUpComponent;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.DefaultModeComponent
{
    internal class DefaultApplicationMode : IApplicationMode
    {
        private readonly Func<MainPageDetail> _createDetail;
        private readonly Func<MainPageMaster> _createMaster;
        private readonly Func<StartingUpApplicationMode> _createStartUpMode;
        private readonly ITinyMessengerHub _hub;
        private readonly Func<MainPage> _mainPageFactory;
        private App _application;

        public DefaultApplicationMode(Func<MainPage> mainPageFactory,
            Func<MainPageMaster> createMaster, Func<MainPageDetail> createDetail, ITinyMessengerHub hub,
            Func<StartingUpApplicationMode> createStartUpMode)
        {
            _mainPageFactory = mainPageFactory;
            _createMaster = createMaster;
            _createDetail = createDetail;
            _hub = hub;
            _createStartUpMode = createStartUpMode;

            _hub.Subscribe<LogoutSuccessEvent>(OnLogoutSuccess);
        }

        public void SetApplication(App application)
        {
            _application = application;
            var applicationMainPage = _mainPageFactory();
            applicationMainPage.Master = _createMaster();
            applicationMainPage.Detail = new NavigationPage(_createDetail());
            _application.MainPage = applicationMainPage;
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

        private void OnLogoutSuccess(LogoutSuccessEvent obj)
        {
            _application.SetMode(_createStartUpMode());
        }
    }
}