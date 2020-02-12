using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerMasterDetailPage : MasterDetailPage
    {
        private readonly ITinyMessengerHub _hub;

        public CustomerMasterDetailPage(CustomerMasterDetailPageMaster master, ITinyMessengerHub hub)
        {
            _hub = hub;
            InitializeComponent();
            Master = master;
            _hub.Subscribe<NavigateToCommand>(OnNavigateTo);
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