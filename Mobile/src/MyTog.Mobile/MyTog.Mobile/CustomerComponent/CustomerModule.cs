using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    [Export(typeof(IModule))]
    internal class CustomerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerMasterDetailPageMasterViewModel>();
            builder.RegisterType<CustomerMasterDetailPageMaster>();
            builder.RegisterType<RequestAppointmentMenuItem>().As<ICustomerMenuItem>();
            builder.RegisterType<RequestAppointmentPage>();
            builder.RegisterType<CustomerApplicationMode>();
            builder.RegisterType<CustomerMasterDetailPage>();
        }
    }
}