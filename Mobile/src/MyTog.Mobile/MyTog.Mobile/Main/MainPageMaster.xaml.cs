﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        public ListView ListView;

        public MainPageMaster(MainPageMasterViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}