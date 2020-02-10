using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;
using AutoMapper;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    [Export(typeof(IModule))]
    internal class SQLiteModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqLiteAccessTokenLifetimeStore>().As<IAccessTokenLifetimeStore>();
            builder.RegisterType<SQLiteAccessTokenLifetimeQuery>().As<IAccessTokenLifetimeQuery>();
            builder.RegisterType<SQLiteApplicationModeStore>().As<IApplicationModeStore>();
            builder.RegisterType<SQLiteAutoMapperProfile>().As<Profile>();
        }
    }
}