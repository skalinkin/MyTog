﻿using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    [Export(typeof(IModule))]
    internal class MyTogModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TinyMessengerHub>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<App>().As<Application>();
            builder.RegisterType<StartingUpViewModel>();
            builder.RegisterType<StartingUpPage>();
            builder.RegisterType<DefaultApplicationMode>();
            builder.RegisterType<StartingUpApplicationMode>().As<IApplicationMode>();
        }
    }
}