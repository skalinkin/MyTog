﻿using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;
using Kalinkin.MyTog.Mobile;
using MyTog.Mobile.Droid;

namespace MyTog.Mobile.Android.Autofac
{
    [Export(typeof(IModule))]
    internal class AndroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Auth0AuthenticationService>().As<IAuthenticationService>();
        }
    }
}