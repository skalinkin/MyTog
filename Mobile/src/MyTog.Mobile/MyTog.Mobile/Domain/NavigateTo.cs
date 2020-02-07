using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    public class NavigateTo:ITinyMessage
    {
        public object Sender { get; set; }
        public IMenuItem Target { get; set; }
    }
}