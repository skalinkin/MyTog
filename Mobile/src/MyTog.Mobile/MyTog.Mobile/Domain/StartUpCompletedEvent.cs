using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    internal class StartUpCompletedEvent : ITinyMessage
    {
        public object Sender { get; set; }
    }
}