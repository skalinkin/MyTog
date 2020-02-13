using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    internal class ScheduleService : IApplicationService
    {
        private readonly ITinyMessengerHub _hub;
        private readonly PingService _service;

        public ScheduleService(ITinyMessengerHub hub, PingService service)
        {
            _hub = hub;
            _service = service;

            _hub.Subscribe<ScheduleAppointmentCommand>(OnScheduleAppointment);
        }

        private void OnScheduleAppointment(ScheduleAppointmentCommand obj)
        {
            //call api
            var content = _service.PingAsync();
        }
    }
}