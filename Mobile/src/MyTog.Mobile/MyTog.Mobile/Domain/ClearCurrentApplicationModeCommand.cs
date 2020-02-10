using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    internal class ClearCurrentApplicationModeCommand:ITinyMessage
    {
        public object Sender { get; }
    }
}