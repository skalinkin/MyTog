using System;
using System.Linq;
using Kalinkin.MyTog.Mobile.Domain;
using Kalinkin.MyTog.Mobile.PhotographerComponent;
using Kalinkin.MyTog.Mobile.StartingUpComponent;
using TinyMessenger;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    internal class InvalidatedApplicationMode : IApplicationMode
    {
        private readonly IApplicationModeStore _applicationModeStore;
        private readonly Func<PhotographerApplicationMode> _createPhotographerApplicationMode;
        private readonly Func<SelectingModePage> _createSelectModePage;
        private readonly ITinyMessengerHub _hub;
        private readonly Func<StartingUpPage> _pageFactory;
        private App _application;

        public InvalidatedApplicationMode(Func<StartingUpPage> pageFactory,
            ITinyMessengerHub hub, Func<PhotographerApplicationMode> createPhotographerApplicationMode,
            Func<SelectingModePage> createSelectModePage,
            IApplicationModeStore applicationModeStore)
        {
            _pageFactory = pageFactory;
            _hub = hub;
            _createPhotographerApplicationMode = createPhotographerApplicationMode;
            _createSelectModePage = createSelectModePage;
            _applicationModeStore = applicationModeStore;

            _hub.Subscribe<AuthenticationSuccessfulEvent>(OnAuthenticationSuccessful);
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
        }

        public void HandleOnSleep()
        {
        }

        private async void OnAuthenticationSuccessful(AuthenticationSuccessfulEvent obj)
        {
            var records = await _applicationModeStore.GetAllItems();
            if (records.Any())
            {
                var lastMode = records.OrderByDescending(m => m.SetTime).First();
                if (lastMode.Mode == "PhotographerApplicationMode")
                {
                    void SetPhotographyMode()
                    {
                        _application.SetMode(_createPhotographerApplicationMode());
                    }

                    if (MainThread.IsMainThread)
                    {
                        SetPhotographyMode();
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(SetPhotographyMode);
                    }
                }
            }
            else
            {
                void ShowSelectModePage()
                {
                    _application.MainPage = _createSelectModePage();
                }

                if (MainThread.IsMainThread)
                {
                    ShowSelectModePage();
                }
                else
                {
                    Device.BeginInvokeOnMainThread(ShowSelectModePage);
                }
            }
        }
    }
}