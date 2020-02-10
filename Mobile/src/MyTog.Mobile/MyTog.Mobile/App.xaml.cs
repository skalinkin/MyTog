using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    public partial class App : Application
    {
        private readonly ITinyMessengerHub _hub;
        private readonly IApplicationMode _initMode;
        private IApplicationMode _currentMode;

        public App(ITinyMessengerHub hub, IApplicationMode initMode)
        {
            _hub = hub;
            _initMode = initMode;
            InitializeComponent();
        }

        public bool Started { get; set; }

        public void SetMode(IApplicationMode mode)
        {
            _currentMode = mode;
        }

        protected override void OnStart()
        {
            _currentMode = _initMode;
            _currentMode.SetApplication(this);
            _currentMode.HandleOnStart();
        }

        protected override void OnSleep()
        {
            _currentMode.HandleOnSleep();
        }

        protected override void OnResume()
        {
            _currentMode.HandleOnResume();
        }
    }
}