using System.Collections.Generic;
using System.Threading.Tasks;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    internal class SqlLiteAccessTokenLifetimeQuery : IAccessTokenLifetimeQuery
    {
        private readonly IAccessTokenLifetimeStore _store;

        public SqlLiteAccessTokenLifetimeQuery(IAccessTokenLifetimeStore store)
        {
            _store = store;
        }

        public Task<IEnumerable<AccessTokenLifetime>> GetItemsAsync()
        {
            return _store.GetAllItems();
        }
    }
}