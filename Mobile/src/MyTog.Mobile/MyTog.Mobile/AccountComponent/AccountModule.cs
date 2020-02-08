using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;

namespace Kalinkin.MyTog.Mobile.AccountComponent
{
    [Export(typeof(IModule))]
    internal class AccountModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountMenuItem>().As<IMenuItem>();
            builder.RegisterType<AccountPage>();
            builder.RegisterType<AccountViewModel>();
        }
    }
}