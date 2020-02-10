using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;
using AutoMapper;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    [Export(typeof(IModule))]
    internal class SqlLiteModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqLiteAccessTokenLifetimeStore>().As<IAccessTokenLifetimeStore>();
            builder.RegisterType<SqlLiteAccessTokenLifetimeQuery>().As<IAccessTokenLifetimeQuery>();
            builder.RegisterType<SqlLiteAutoMapperProfile>().As<Profile>();
        }
    }
}