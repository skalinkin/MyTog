using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    internal class ClearCurrentAccountHandler
    {
        private readonly ITinyMessengerHub _hub;
        private readonly IAccessTokenLifetimeStore _store;

        public ClearCurrentAccountHandler(ITinyMessengerHub hub, IAccessTokenLifetimeStore store)
        {
            _hub = hub;
            _store = store;

            _hub.Subscribe<ClearCurrentAccountCommand>(OnClearCurrentAccount);
        }

        private async void OnClearCurrentAccount(ClearCurrentAccountCommand obj)
        {
            var items = await _store.GetAllItems();

            foreach (var item in items)
            {
                await _store.DeleteItem(item);
            }
        }
    }
}