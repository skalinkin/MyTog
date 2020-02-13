using System;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    internal class ScheduleAppointmentCommand : ITinyMessage
    {
        public object Sender { get; }
        public string Message { get; set; }
    }
}