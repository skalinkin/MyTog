using System;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    internal class StartingUpApplicationMode : IApplicationMode
    {
        private readonly IAuthenticationService _authentication;
        private readonly Func<DefaultApplicationMode> _createDefaultApplicationMode;
        private readonly Func<StartingUpPage> _pageFactory;
        private readonly ITinyMessengerHub _messenger;

        private App _application;

        public StartingUpApplicationMode(Func<StartingUpPage> pageFactory, IAuthenticationService authentication,
            ITinyMessengerHub messenger, Func<DefaultApplicationMode> createDefaultApplicationMode)
        {
            _pageFactory = pageFactory;
            _authentication = authentication;
            _messenger = messenger;
            _createDefaultApplicationMode = createDefaultApplicationMode;

            _messenger.Subscribe<StartUpCompleted>(OnStartUpCompleted);
        }

        public void SetApplication(App application)
        {
            _application = application;
            _application.MainPage = _pageFactory();
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

        private void OnStartUpCompleted(StartUpCompleted obj)
        {
            var mode = _createDefaultApplicationMode();

            Device.BeginInvokeOnMainThread(() => _application.TransitionTo(mode));
        }
    }
}