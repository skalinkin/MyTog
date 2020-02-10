using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    public class LogoutSuccessEvent:ITinyMessage
    {
        public object Sender { get; }
    }
}