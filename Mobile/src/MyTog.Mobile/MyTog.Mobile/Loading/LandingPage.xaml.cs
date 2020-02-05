using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile
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