using System;
using Kalinkin.MyTog.Mobile.StartingUpComponent;

namespace Kalinkin.MyTog.Mobile
{
    internal class UnAuthorizedApplicationMode:IApplicationMode
    {
        private readonly Func<SelectingModePage> _createSelectingPage;

        private App _application;

        public UnAuthorizedApplicationMode(Func<SelectingModePage> createSelectingPage)
        {
            _createSelectingPage = createSelectingPage;
        }
        public void SetApplication(App app)
        {
            _application = app;
            _application.InsureMainThread(() => _application.MainPage = _createSelectingPage());
        }

        public void HandleOnStart()
        {
            throw new System.NotImplementedException();
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