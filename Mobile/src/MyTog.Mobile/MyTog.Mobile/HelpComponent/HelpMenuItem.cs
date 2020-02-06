using System;

namespace Kalinkin.MyTog.Mobile.HelpComponent
{
    internal class HelpMenuItem : IMenuItem
    {
        public string Title => "Help";

        public Type TargetType => typeof(HelpPage);
    }
}