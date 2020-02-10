using System.Collections.Generic;
using System.Threading.Tasks;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile
{
    public interface IAccessTokenLifetimeQuery
    {
        Task<IEnumerable<AccessTokenLifetime>> GetItemsAsync();
    }
}