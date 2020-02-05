﻿using System;
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
        public LandingPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            var service = TinyIoC.TinyIoCContainer.Current.Resolve<IAuthenticationService>();
            service.AuthenticateAsync();
        }
    }
}