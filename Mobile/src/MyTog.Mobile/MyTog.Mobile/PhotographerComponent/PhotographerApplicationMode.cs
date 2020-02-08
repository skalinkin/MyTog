using System;
using Kalinkin.MyTog.Mobile.Domain;
using Kalinkin.MyTog.Mobile.Main;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.PhotographerComponent
{
    internal class PhotographerApplicationMode : IApplicationMode
    {
        private readonly AuthenticationService _authentication;
        private readonly Func<MainPageDetail> _createDetail;
        private readonly ITinyMessengerHub _hub;
        private readonly Func<DefaultApplicationMode> _createDefaultMode;
        private readonly Func<MainPageMaster> _createMaster;
        private readonly Func<MainPage> _mainPageFactory;
        private App _application;

        public PhotographerApplicationMode(Func<MainPage> mainPageFactory, AuthenticationService authentication,
            Func<MainPageMaster> createMaster, Func<MainPageDetail> createDetail, ITinyMessengerHub hub, Func<DefaultApplicationMode> createDefaultMode)
        {
            _mainPageFactory = mainPageFactory;
            _authentication = authentication;
            _createMaster = createMaster;
            _createDetail = createDetail;
            _hub = hub;
            _createDefaultMode = createDefaultMode;

            _hub.Subscribe<Logout>(OnLogout);
            _hub.Subscribe<LogoutSuccess>(OnLogoutSuccess);
        }

        private void OnLogoutSuccess(LogoutSuccess obj)
        {
            _application.SetMode(_createDefaultMode());
        }

        private void OnLogout(Logout obj)
        {
            _authentication.LogoutAsync();
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
    }
}