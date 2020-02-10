using System;
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

            _hub.Subscribe<StartUpCompletedEvent>(OnStartUpCompleted);
            _hub.Subscribe<AuthenticationSuccessfulEvent>(OnAuthenticationSuccessful);
            _hub.Subscribe<LunchPhotographerMode>(OnLunchPhotographerMode);
        }

        public void SetApplication(App application)
        {
            _application = application;
            if (_application.Started)
            {
                HandleOnStart();
            }
        }

        public void HandleOnStart()
        {
            Func<Page> action = () => _application.MainPage = _pageFactory();
            if (MainThread.IsMainThread)
            {
                action();
            }
            else
            {
                Device.InvokeOnMainThreadAsync(action).Wait();
            }

            _application.Started = true;
        }

        public void HandleOnResume()
        {
        }

        public void HandleOnSleep()
        {
        }

        private void OnLunchPhotographerMode(LunchPhotographerMode obj)
        {
            try
            {
                var mode = _createPhotographerApplicationMode();
                Device.BeginInvokeOnMainThread(() => _application.SetMode(mode));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void OnAuthenticationSuccessful(AuthenticationSuccessfulEvent obj)
        {
            void Action()
            {
                _application.MainPage = _createSelectModePage();
            }

            if (MainThread.IsMainThread)
            {
                Action();
            }
            else
            {
                Device.BeginInvokeOnMainThread(Action);
            }
        }

        private void OnStartUpCompleted(StartUpCompletedEvent obj)
        {
        }
    }
}