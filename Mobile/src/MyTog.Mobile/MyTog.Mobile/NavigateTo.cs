using System;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    public class NavigateTo:ITinyMessage
    {
        public object Sender { get; set; }
        public IMenuItem Target { get; set; }
    }
}