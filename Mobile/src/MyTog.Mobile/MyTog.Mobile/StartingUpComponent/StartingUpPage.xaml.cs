using Kalinkin.MyTog.Mobile.StartingUpComponent;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartingUpPage : ContentPage
    {
        public StartingUpPage(StartingUpViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.Start();
        }
    }
}