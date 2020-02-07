using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Domain
{
    internal class StartUpCompleted : ITinyMessage
    {
        public object Sender { get; set; }
    }
}