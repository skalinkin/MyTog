﻿using Kalinkin.MyTog.Mobile.Main;
using Kalinkin.MyTog.Mobile.SQLiteModule;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    public class TinyIoCBootstrapper
    {
        public void Initialize()
        {
            TinyIoC.TinyIoCContainer.Current.Register<Page, MainPage>();
            TinyIoC.TinyIoCContainer.Current.Register<MyTogDatabase>().AsSingleton();
            TinyIoC.TinyIoCContainer.Current.Register<Application, App>();
        }
        public Application GetApplication()
        {
            return TinyIoC.TinyIoCContainer.Current.Resolve<Application>();
        }
    }
}