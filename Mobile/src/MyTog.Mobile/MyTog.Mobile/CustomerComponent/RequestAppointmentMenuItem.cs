using System;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    internal class RequestAppointmentMenuItem : ICustomerMenuItem
    {
        private readonly Func<RequestAppointmentPage> _createPage;

        public RequestAppointmentMenuItem(Func<RequestAppointmentPage> createPage)
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