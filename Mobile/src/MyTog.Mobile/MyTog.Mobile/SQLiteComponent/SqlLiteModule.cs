using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
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