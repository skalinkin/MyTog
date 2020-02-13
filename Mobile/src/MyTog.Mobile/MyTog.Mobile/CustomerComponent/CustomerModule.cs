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
            builder.RegisterType<ScheduleService>().As<IApplicationService>();
            builder.RegisterType<CustomerMasterDetailPageMasterViewModel>();
            builder.RegisterType<CustomerMasterDetailPageMaster>();
            builder.RegisterType<ScheduleAppointmentMenuItem>().As<ICustomerMenuItem>();
            builder.RegisterType<ScheduleAppointmentViewModel>();
            builder.RegisterType<ScheduleAppointmentPage>();
            builder.RegisterType<CustomerApplicationMode>();
            builder.RegisterType<CustomerMasterDetailPage>();
        }
    }
}