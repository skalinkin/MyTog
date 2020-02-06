using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    public class StartUpStatus:ITinyMessage
    {
        public object Sender { get; set; }
        public string StatusText { get; set; }
    }
}