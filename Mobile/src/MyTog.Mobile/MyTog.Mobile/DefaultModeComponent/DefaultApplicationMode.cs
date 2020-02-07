using System;
using Kalinkin.MyTog.Mobile.Main;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    internal class DefaultApplicationMode : IApplicationMode
    {
        private readonly AuthenticationService _authentication;
        private readonly Func<MainPageDetail> _createDetail;
        private readonly Func<MainPageMaster> _createMaster;
        private readonly Func<MainPage> _mainPageFactory;
        private App _application;

        public DefaultApplicationMode(Func<MainPage> mainPageFactory, AuthenticationService authentication,
            Func<MainPageMaster> createMaster, Func<MainPageDetail> createDetail)
        {
            _mainPageFactory = mainPageFactory;
            _authentication = authentication;
            _createMaster = createMaster;
            _createDetail = createDetail;
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
            _authentication.AuthenticateAsync();
        }

        public void HandleOnResume()
        {
        }

        public void HandleOnSleep()
        {
        }
    }
}