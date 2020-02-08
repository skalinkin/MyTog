using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;

namespace Kalinkin.MyTog.Mobile.Auth0Component
{
    [Export(typeof(IModule))]
    internal class AuthModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new AuthConfig
                {ClientId = "yKKtP1bkVMtbVXO9dO2y63ShQBirl5ZN", Domain = "mytog.auth0.com"}).AsSelf();
        }
    }
}