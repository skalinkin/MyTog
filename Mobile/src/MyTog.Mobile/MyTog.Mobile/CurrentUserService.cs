using System;
using System.Linq;
using System.Threading.Tasks;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    public class CurrentUserService : IApplicationService
    {
        private readonly ITinyMessengerHub _hub;
        private readonly IAccessTokenLifetimeStore _store;

        public CurrentUserService(ITinyMessengerHub hub, IAccessTokenLifetimeStore store)
        {
            _hub = hub;
            _store = store;
        }

        public async Task<bool> IsUserNeedAuthentication()
        {
            var tokens = await _store.GetAllItems();
            if (!tokens.Any())
            {
                return true;
            }
            var lastToken = tokens.OrderByDescending(i => i.AuthenticationTime).First();
            var now = DateTime.Now;
            return lastToken.AccessTokenExpiration < now;
        }
    }
}