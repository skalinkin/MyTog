using System.Collections.Generic;

namespace Kalinkin.MyTog.Mobile
{
    internal interface IAccountQuery
    {
        IEnumerable<Account> GetAll();
    }
}