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
        private readonly IApplicationModeStore _applicationModeStore;
        private readonly Func<PhotographerApplicationMode> _createPhotographerApplicationMode;
        private readonly Func<SelectingModePage> _createSelectModePage;
        private readonly CurrentUserService _currentUser;
        private readonly ITinyMessengerHub _hub;
        private App _application;
        private readonly Func<StartingUpPage> _pageFactory;

        public StartingUpApplicationMode(Func<StartingUpPage> pageFactory,
            ITinyMessengerHub hub, Func<PhotographerApplicationMode> createPhotographerApplicationMode,
            Func<SelectingModePage> createSelectModePage, CurrentUserService currentUser,
            IApplicationModeStore applicationModeStore)
        {
            _pageFactory = pageFactory;
            _hub = hub;
            _createPhotographerApplicationMode = createPhotographerApplicationMode;
            _createSelectModePage = createSelectModePage;
            _currentUser = currentUser;
            _applicationModeStore = applicationModeStore;

            _hub.Subscribe<AuthenticationSuccessfulEvent>(OnAuthenticationSuccessful);
            _hub.Subscribe<LunchPhotographerModeCommand>(OnLunchPhotographerMode);
        }

        public void SetApplication(App app)
        {
            _application = app;
        }

        public async void HandleOnStart()
        {
            if (await _currentUser.IsUserNeedAuthentication())
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
            }
            else
            {
                OnAuthenticationSuccessful(null);
            }

            _application.Started = true;
        }

        public void HandleOnResume()
        {
            _hub.Publish(new ApplicationResumedEvent());
        }

        public void HandleOnSleep()
        {
        }

        private void OnLunchPhotographerMode(LunchPhotographerModeCommand obj)
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