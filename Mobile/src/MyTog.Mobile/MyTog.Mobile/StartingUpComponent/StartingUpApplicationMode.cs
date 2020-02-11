using System;
using System.Linq;
using Kalinkin.MyTog.Mobile.Domain;
using Kalinkin.MyTog.Mobile.PhotographerComponent;
using TinyMessenger;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.StartingUpComponent
{
    internal class StartingUpApplicationMode : IApplicationMode
    {
        private readonly Func<PhotographerApplicationMode> _createPhotographerApplicationMode;
        private readonly Func<SelectingModePage> _createSelectModePage;
        private readonly ITinyMessengerHub _hub;
        private readonly Func<StartingUpPage> _pageFactory;
        private App _application;

        public StartingUpApplicationMode(Func<StartingUpPage> pageFactory,
            ITinyMessengerHub hub, Func<PhotographerApplicationMode> createPhotographerApplicationMode,
            Func<SelectingModePage> createSelectModePage)
        {
            _pageFactory = pageFactory;
            _hub = hub;
            _createPhotographerApplicationMode = createPhotographerApplicationMode;
            _createSelectModePage = createSelectModePage;

        }

        public void SetApplication(App app)
        {
            _application = app;
            _application.InsureMainThread(() => _application.MainPage = _pageFactory());
        }

        public void HandleOnStart()
        {
            throw new ApplicationException("Code should not get here.");
        }

        public void HandleOnResume()
        {
            _hub.Publish(new ApplicationResumedEvent());
        }

        public void HandleOnSleep()
        {
        }

    }
}