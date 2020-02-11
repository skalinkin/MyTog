using System;
using System.Linq;
using Kalinkin.MyTog.Mobile.Domain;
using Kalinkin.MyTog.Mobile.PhotographerComponent;
using Kalinkin.MyTog.Mobile.StartingUpComponent;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    internal class ApplicationModeController : IApplicationService
    {
        private readonly App _app;
        private readonly IApplicationModeStore _applicationModeStore;
        private readonly AuthenticationService _authentication;
        private readonly Func<InvalidatedApplicationMode> _createInValidatedApplicationMode;
        private readonly Func<PhotographerApplicationMode> _createPhotographerMode;
        private readonly Func<StartingUpApplicationMode> _createStartUpMode;
        private readonly Func<UnAuthorizedApplicationMode> _createUnAuthorizedApplicationMode;
        private readonly CurrentUserService _currentUserService;
        private readonly ITinyMessengerHub _hub;

        public ApplicationModeController(ITinyMessengerHub hub, Application app,
            Func<PhotographerApplicationMode> createPhotographerMode, Func<StartingUpApplicationMode> createStartUpMode,
            Func<InvalidatedApplicationMode> createInValidatedApplicationMode,
            IApplicationModeStore applicationModeStore,
            Func<UnAuthorizedApplicationMode> createUnAuthorizedApplicationMode, AuthenticationService authentication,
            CurrentUserService currentUserService)
        {
            _hub = hub;
            _createPhotographerMode = createPhotographerMode;
            _createStartUpMode = createStartUpMode;
            _createInValidatedApplicationMode = createInValidatedApplicationMode;
            _applicationModeStore = applicationModeStore;
            _createUnAuthorizedApplicationMode = createUnAuthorizedApplicationMode;
            _authentication = authentication;
            _currentUserService = currentUserService;
            _app = (App) app;

            _hub.Subscribe<LunchPhotographerModeCommand>(OnLunchPhotographerMode);
            _hub.Subscribe<LogoutSuccessEvent>(OnLogoutSuccess);
            _hub.Subscribe<ApplicationStartedEvent>(OnApplicationStarted);
            _hub.Subscribe<AuthenticationSuccessfulEvent>(OnAuthenticationSuccessful);
        }


        private async void OnApplicationStarted(ApplicationStartedEvent obj)
        {
            if (await _currentUserService.IsUserNeedAuthentication())
            {
                _app.SetMode(_createInValidatedApplicationMode());
            }
            else
            {
                OnAuthenticationSuccessful(null);
            }
        }

        private void OnLogoutSuccess(LogoutSuccessEvent obj)
        {
            _app.SetMode(_createStartUpMode());
        }

        private void OnLunchPhotographerMode(LunchPhotographerModeCommand obj)
        {
            _app.SetMode(_createPhotographerMode());
        }

        private async void OnAuthenticationSuccessful(AuthenticationSuccessfulEvent obj)
        {
            var records = await _applicationModeStore.GetAllItems();
            if (records.Any())
            {
                var lastMode = records.OrderByDescending(m => m.SetTime).First();
                if (lastMode.Mode == "PhotographerApplicationMode")
                {
                    _app.SetMode(_createPhotographerMode());
                }
            }
            else
            {
                _app.SetMode(_createUnAuthorizedApplicationMode());
            }
        }
    }
}