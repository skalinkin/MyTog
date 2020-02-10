using System;
using Kalinkin.MyTog.Mobile.StartingUpComponent;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    internal class ApplicationModeController : IApplicationService
    {
        private readonly App _app;
        private readonly Func<StartingUpApplicationMode> _createSrartUpMode;
        private readonly ITinyMessengerHub _hub;

        public ApplicationModeController(ITinyMessengerHub hub, Application app,
            Func<StartingUpApplicationMode> createSrartUpMode)
        {
            _hub = hub;
            _createSrartUpMode = createSrartUpMode;
            _app = (App) app;

        }
    }
}