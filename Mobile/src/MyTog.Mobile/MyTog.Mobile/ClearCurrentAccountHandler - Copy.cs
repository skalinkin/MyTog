using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    internal class ClearCurrentApplicationModeHandler : IApplicationService
    {
        private readonly ITinyMessengerHub _hub;
        private readonly IApplicationModeStore _store;

        public ClearCurrentApplicationModeHandler(ITinyMessengerHub hub, IApplicationModeStore store)
        {
            _hub = hub;
            _store = store;

            _hub.Subscribe<ClearCurrentApplicationModeCommand>(ClearApplicationMode);
        }

        private async void ClearApplicationMode(ClearCurrentApplicationModeCommand clearCurrentApplicationModeCommand)
        {
            var items = await _store.GetAllItems();

            foreach (var item in items)
            {
                await _store.DeleteItem(item);
            }
        }
    }
}