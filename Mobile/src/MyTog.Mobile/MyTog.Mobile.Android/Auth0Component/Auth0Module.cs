using System.ComponentModel.Composition;
using Auth0.OidcClient;
using Autofac;
using Autofac.Core;
using Kalinkin.MyTog.Mobile;
using Kalinkin.MyTog.Mobile.Auth0Component;

namespace MyTog.Mobile.Droid.Auth0Component
{
    [Export(typeof(IModule))]
    internal class Auth0Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Auth0AuthenticationService>().As<AuthenticationService>();
            builder.Register(c =>
            {
                var config = c.Resolve<AuthConfig>();
                return new Auth0ClientOptions {Domain = config.Domain, ClientId = config.ClientId};
            }).AsSelf();
            builder.RegisterType<Auth0Client>();
        }
    }
}