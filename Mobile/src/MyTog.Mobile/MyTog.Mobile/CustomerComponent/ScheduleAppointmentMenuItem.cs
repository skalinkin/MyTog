using System;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    internal class ScheduleAppointmentMenuItem : ICustomerMenuItem
    {
        private readonly Func<ScheduleAppointmentPage> _createPage;

        public ScheduleAppointmentMenuItem(Func<ScheduleAppointmentPage> createPage)
        {
            _createPage = createPage;
        }

        public string Title => "Schedule Appointment";

        public Page CreateTarget()
        {
            return _createPage();
        }
    }
}