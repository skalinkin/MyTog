using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile.StartingUpComponent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectingModePage : ContentPage
    {
        public SelectingModePage(SelectingModeViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}