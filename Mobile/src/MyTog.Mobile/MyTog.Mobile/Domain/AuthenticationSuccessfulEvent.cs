using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    public class AuthenticationSuccessfulEvent:ITinyMessage
    {
        public object Sender { get; }
    }
}