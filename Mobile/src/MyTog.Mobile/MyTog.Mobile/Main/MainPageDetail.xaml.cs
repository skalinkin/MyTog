using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage
    {
        private readonly IAuthenticationService _Auth;

        public MainPageDetail(IAuthenticationService auth)
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