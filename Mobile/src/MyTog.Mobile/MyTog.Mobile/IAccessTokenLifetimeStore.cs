using System.Collections.Generic;
using System.Threading.Tasks;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile
{
    public interface IAccessTokenLifetimeStore
    {
        Task<int> SaveItemAsync(AccessTokenLifetime item);
        Task<List<AccessTokenLifetime>> GetItemsAsync();
    }
}