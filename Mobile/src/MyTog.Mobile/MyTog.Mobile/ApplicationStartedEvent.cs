using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    internal class ApplicationStartedEvent:ITinyMessage
    {
        public object Sender { get; }
    }
}