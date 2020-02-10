using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    public class AuthenticationFailedEvent:ITinyMessage
    {
        public object Sender { get; }
        public string Error { get; set; }
    }
}