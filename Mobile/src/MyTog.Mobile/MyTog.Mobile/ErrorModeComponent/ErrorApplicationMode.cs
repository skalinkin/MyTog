using System;
using Kalinkin.MyTog.Mobile.Main;

namespace Kalinkin.MyTog.Mobile.ErrorModeComponent
{
    internal class ErrorApplicationMode : IApplicationMode
    {
        private readonly Func<MainPage> _mainPageFactory;
        private App _application;

        public ErrorApplicationMode(Func<MainPage> mainPageFactory)
        {
            _mainPageFactory = mainPageFactory;
        }

        public void SetApplication(App application)
        {
            _application = application;
            _application.MainPage = _mainPageFactory();
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