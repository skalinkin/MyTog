using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    internal class ClearCurrentAccountCommand:ITinyMessage
    {
        public object Sender { get; }
    }
}