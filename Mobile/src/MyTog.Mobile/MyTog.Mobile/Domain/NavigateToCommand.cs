using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    public class NavigateToCommand:ITinyMessage
    {
        public object Sender { get; set; }
        public IMenuItem Target { get; set; }
    }
}