using System.ComponentModel.Composition;
using System.Net;
using Autofac;
using Autofac.Core;
using MyTog.Mobile.Droid;

namespace Kalinkin.MyTog.Mobile
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