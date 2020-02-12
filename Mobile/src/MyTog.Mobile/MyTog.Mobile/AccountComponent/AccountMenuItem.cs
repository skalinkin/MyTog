using System;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.AccountComponent
{
    internal class AccountMenuItem : IMenuItem, ICustomerMenuItem
    {
        private readonly Func<AccountPage> _createPage;

        public AccountMenuItem(Func<AccountPage> createPage)
        {
            _createPage = createPage;
        }

        public string Title => "Account";

        public Page CreateTarget()
        {
            return _createPage();
        }
    }
}