using System;
using Kalinkin.MyTog.Mobile.Main;

namespace Kalinkin.MyTog.Mobile
{
    internal class ErrorApplicationMode : IApplicationMode
    {
        private readonly Func<MainPage> _mainPageFactory;
        private readonly AuthenticationService _authentication;

        public ErrorApplicationMode(Func<MainPage> mainPageFactory, AuthenticationService authentication)
        {
            _mainPageFactory = mainPageFactory;
            _authentication = authentication;
        }
        private App _application;

        public void SetApplication(App application)
        {
            _application = application;
            _application.MainPage = _mainPageFactory();
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