using System;
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
            _messenger.Subscribe<NavigateTo>(OnNavigateTo);
        }

        private void OnNavigateTo(NavigateTo obj)
        {
            if (obj.Target == null)
            {
                return;
            }

            var page = (Page) Activator.CreateInstance(obj.Target.TargetType);
            page.Title = obj.Target.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;
        }
    }
}