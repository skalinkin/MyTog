using System;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.HelpComponent
{
    internal class HelpMenuItem : IMenuItem
    {
        private readonly Func<HelpPage> _createPage;

        public HelpMenuItem(Func<HelpPage> createPage)
        {
            _createPage = createPage;
        }

        public string Title => "Help";

        public Type TargetType => typeof(HelpPage);
        public Page CreateTarget()
        {
            return _createPage();
        }
    }
}