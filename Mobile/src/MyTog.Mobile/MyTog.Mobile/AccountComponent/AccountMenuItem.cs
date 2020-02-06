using System;

namespace Kalinkin.MyTog.Mobile.AccountComponent
{
    internal class AccountMenuItem : IMenuItem
    {
        public string Title => "Account";

        public Type TargetType => typeof(AccountPage);
    }
}