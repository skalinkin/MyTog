using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;
using MyTog.Mobile;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    [Export(typeof(IModule))]
    internal class SqlLiteModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyTogDatabase>().SingleInstance();
        }
    }
}