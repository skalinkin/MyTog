using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile.Loading
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        private readonly IAuthenticationService _Auth;

        public LandingPage(IAuthenticationService auth)
        {
            _Auth = auth;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            _Auth.AuthenticateAsync();
        }
    }
}