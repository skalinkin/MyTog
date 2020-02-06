using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;

namespace Kalinkin.MyTog.Mobile.HelpComponent
{
    [Export(typeof(IModule))]
    internal class HelpModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HelpMenuItem>().As<IMenuItem>();
            builder.RegisterType<HelpPage>();
        }
    }
}