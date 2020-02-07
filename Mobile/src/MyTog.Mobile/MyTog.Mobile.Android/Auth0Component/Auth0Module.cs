using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;
using Kalinkin.MyTog.Mobile;

namespace MyTog.Mobile.Droid.Auth0Component
{
    [Export(typeof(IModule))]
    internal class Auth0Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Auth0AuthenticationService>().As<AuthenticationService>();
        }
    }
}