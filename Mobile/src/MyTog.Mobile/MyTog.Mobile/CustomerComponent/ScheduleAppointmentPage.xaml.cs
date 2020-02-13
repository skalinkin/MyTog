using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleAppointmentPage : ContentPage
    {

        public ScheduleAppointmentPage(ScheduleAppointmentViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}