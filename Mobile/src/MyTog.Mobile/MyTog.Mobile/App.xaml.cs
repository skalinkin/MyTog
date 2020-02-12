using System;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    public partial class App : Application
    {
        private readonly ITinyMessengerHub _hub;
        private readonly IApplicationMode _initMode;
        private readonly IApplicationModeStore _applicationModeStore;
        private IApplicationMode _currentMode;

        public App(ITinyMessengerHub hub, IApplicationMode initMode, IApplicationModeStore applicationModeStore)
        {
            _hub = hub;
            _initMode = initMode;
            _applicationModeStore = applicationModeStore;
            InitializeComponent();
        }

        public bool Started { get; set; }

        public void SetMode(IApplicationMode mode)
        {
            _currentMode = mode;
            _currentMode.SetApplication(this);
            var typeName = _currentMode.GetType().Name;
            _applicationModeStore.AddItem(new ApplicationMode() {Mode = typeName, SetTime = DateTime.Now});
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