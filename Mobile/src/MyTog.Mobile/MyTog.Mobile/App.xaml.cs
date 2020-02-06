using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    public partial class App : Application
    {
        private IApplicationMode _currentMode;

        public App(IApplicationMode initialMode)
        {
            InitializeComponent();
            TransitionTo(initialMode);
        }

        public void TransitionTo(IApplicationMode mode)
        {
            _currentMode = mode;
            _currentMode.SetApplication(this);
        }

        protected override void OnStart()
        {
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