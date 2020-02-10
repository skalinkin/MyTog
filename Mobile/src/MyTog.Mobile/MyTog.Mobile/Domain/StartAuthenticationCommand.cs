using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    public class StartAuthenticationCommand:ITinyMessage
    {
        public object Sender { get; }
    }
}