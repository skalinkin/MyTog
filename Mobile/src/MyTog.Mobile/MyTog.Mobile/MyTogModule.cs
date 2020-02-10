﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;
using AutoMapper;
using Kalinkin.MyTog.Mobile.DefaultModeComponent;
using Kalinkin.MyTog.Mobile.PhotographerComponent;
using Kalinkin.MyTog.Mobile.StartingUpComponent;
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
            builder.RegisterType<PhotographerApplicationMode>();
            builder.RegisterType<SelectingModePage>();
            builder.RegisterType<SelectingModeViewModel>();
            builder.RegisterType<StartingUpApplicationMode>();
            builder.RegisterType<StartingUpApplicationMode>().As<IApplicationMode>();
            builder.RegisterType<AccessTokenLifetimeHandler>().As<IApplicationService>();

            builder.Register(c => new MapperConfiguration(cfg => {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                    .CreateMapper(c.Resolve))
                .As<IMapper>();
        }
    }
}