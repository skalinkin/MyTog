using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    internal class LogoutCommand:ITinyMessage
    {
        public object Sender { get; }
    }
}