using System;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        private readonly ITinyMessengerHub _messenger;

        public MainPage(ITinyMessengerHub messenger)
        {
            _messenger = messenger;
            InitializeComponent();
            _messenger.Subscribe<NavigateToCommand>(OnNavigateTo);
        }

        private void OnNavigateTo(NavigateToCommand obj)
        {
            if (obj.Target == null)
            {
                return;
            }

            var page = obj.Target.CreateTarget();
            page.Title = obj.Target.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;
        }
    }
}