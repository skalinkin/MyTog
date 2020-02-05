﻿using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    [Export(typeof(IModule))]
    internal class MyTogModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<App>().As<Application>();
        }
    }
}