using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    internal class ScheduleService : IApplicationService
    {
        private readonly ITinyMessengerHub _hub;

        public ScheduleService(ITinyMessengerHub hub)
        {
            _hub = hub;

            _hub.Subscribe<ScheduleAppointmentCommand>(OnScheduleAppointment);
        }

        private void OnScheduleAppointment(ScheduleAppointmentCommand obj)
        {
            //call api
        }
    }
}