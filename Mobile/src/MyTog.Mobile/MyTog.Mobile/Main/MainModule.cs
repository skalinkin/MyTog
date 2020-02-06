using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;

namespace Kalinkin.MyTog.Mobile.Main
{
    [Export(typeof(IModule))]
    internal class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainPage>();
            builder.RegisterType<MainPageMasterViewModel>();
            builder.RegisterType<MainPageMaster>();
            builder.RegisterType<MainPageDetail>();
        }
    }
}