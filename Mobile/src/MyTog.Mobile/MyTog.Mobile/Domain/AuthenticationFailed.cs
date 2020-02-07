using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    public class AuthenticationFailed:ITinyMessage
    {
        public object Sender { get; }
        public string Error { get; set; }
    }
}