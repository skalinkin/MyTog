using System;
using Kalinkin.MyTog.Mobile.DefaultModeComponent;
using Kalinkin.MyTog.Mobile.Domain;
using Kalinkin.MyTog.Mobile.Main;
using Kalinkin.MyTog.Mobile.StartingUpComponent;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.PhotographerComponent
{
    internal class PhotographerApplicationMode : IApplicationMode
    {
        private readonly Func<MainPageDetail> _createDetail;
        private readonly Func<MainPageMaster> _createMaster;
        private readonly ITinyMessengerHub _hub;
        private readonly IApplicationModeStore _applicationModeStore;
        private readonly Func<MainPage> _mainPageFactory;
        private App _application;

        public PhotographerApplicationMode(Func<MainPage> mainPageFactory,
            Func<MainPageMaster> createMaster, Func<MainPageDetail> createDetail, ITinyMessengerHub hub,
            Func<StartingUpApplicationMode> createStartingUpMode, IApplicationModeStore applicationModeStore)
        {
            _mainPageFactory = mainPageFactory;
            _createMaster = createMaster;
            _createDetail = createDetail;
            _hub = hub;
            _applicationModeStore = applicationModeStore;

            _hub.Subscribe<LogoutSuccessEvent>(m => _application.SetMode(createStartingUpMode()));
        }

        public void SetApplication(App application)
        {
            _application = application;
            var applicationMainPage = _mainPageFactory();
            applicationMainPage.Master = _createMaster();
            applicationMainPage.Detail = new NavigationPage(_createDetail());
            _application.MainPage = applicationMainPage;
            var typeName = GetType().Name;
            _applicationModeStore.AddItem(new ApplicationMode() {Mode = typeName, SetTime = DateTime.Now});
        }

        public void HandleOnStart()
        {
        }

        public void HandleOnResume()
        {
        }

        public void HandleOnSleep()
        {
        }
    }
}