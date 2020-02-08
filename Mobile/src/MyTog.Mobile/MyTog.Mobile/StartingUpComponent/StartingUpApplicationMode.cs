using System;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.StartingUpComponent
{
    internal class StartingUpApplicationMode : IApplicationMode
    {
        private readonly AuthenticationService _authentication;
        private readonly Func<DefaultApplicationMode> _createDefaultApplicationMode;
        private readonly Func<StartingUpPage> _pageFactory;
        private readonly ITinyMessengerHub _messenger;

        private App _application;

        public StartingUpApplicationMode(Func<StartingUpPage> pageFactory, AuthenticationService authentication,
            ITinyMessengerHub messenger, Func<DefaultApplicationMode> createDefaultApplicationMode)
        {
            _pageFactory = pageFactory;
            _authentication = authentication;
            _messenger = messenger;
            _createDefaultApplicationMode = createDefaultApplicationMode;

            _messenger.Subscribe<StartUpCompleted>(OnStartUpCompleted);
            _messenger.Subscribe<AuthenticationSuccessful>(OnAuthenticationSuccessful);
        }

        private void OnAuthenticationSuccessful(AuthenticationSuccessful obj)
        {
            _messenger.Publish(new StartUpStatus {Sender = this, StatusText = "Loading the application."});
            var mode = _createDefaultApplicationMode();
            Device.BeginInvokeOnMainThread(() => _application.SetMode(mode));
        }

        public void SetApplication(App application)
        {
            _application = application;
        }

        public void HandleOnStart()
        {
            Device.BeginInvokeOnMainThread(() => _application.MainPage = _pageFactory());
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
        }
    }
}