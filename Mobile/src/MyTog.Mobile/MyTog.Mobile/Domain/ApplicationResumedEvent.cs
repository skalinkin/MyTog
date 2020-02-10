using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    internal class ApplicationResumedEvent:ITinyMessage
    {
        public object Sender { get; }
    }
}