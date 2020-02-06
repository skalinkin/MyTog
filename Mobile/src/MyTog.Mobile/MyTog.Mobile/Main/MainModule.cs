using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.Main
{
    [Export(typeof(IModule))]
    internal class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainPage>().As<Page>();
            builder.RegisterType<MainPageMasterViewModel>();
            builder.RegisterType<MainPageMaster>();
            builder.RegisterType<MainPageDetail>();
        }
    }
}