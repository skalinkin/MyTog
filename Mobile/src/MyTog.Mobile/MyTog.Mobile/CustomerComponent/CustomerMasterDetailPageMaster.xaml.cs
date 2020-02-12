using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public CustomerMasterDetailPageMaster(CustomerMasterDetailPageMasterViewModel viewModel)
        {
            InitializeComponent();

            
            BindingContext = viewModel;
            ListView = MenuItemsListView;
        }
    }
}