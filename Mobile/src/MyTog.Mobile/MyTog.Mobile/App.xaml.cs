using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    public partial class App : Application
    {
        private IApplicationMode _currentMode;
        private readonly IEnumerable<IApplicationService> _services;

        public App(IApplicationMode initialMode, IEnumerable<IApplicationService> services)
        {
            InitializeComponent();
            _currentMode = initialMode;
            _services = services;
            _currentMode.SetApplication(this);
        }

        public void SetMode(IApplicationMode mode)
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


        public bool Started { get; set; }
    }
}