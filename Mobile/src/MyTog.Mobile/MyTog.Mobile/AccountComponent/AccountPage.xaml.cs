﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile.AccountComponent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        public AccountPage(AccountViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}