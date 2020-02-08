using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    internal class AccessTokenLifetimeHandler : IApplicationService
    {
        private readonly ITinyMessengerHub _hub;
        private readonly IAccessTokenLifetimeStore _store;

        public AccessTokenLifetimeHandler(IAccessTokenLifetimeStore store, ITinyMessengerHub hub)
        {
            _store = store;
            _hub = hub;
            _hub.Subscribe<GenericTinyMessage<AccessTokenLifetime>>(OnMessage);
        }

        private void OnMessage(GenericTinyMessage<AccessTokenLifetime> command)
        {
            _store.SaveItemAsync(command.Content);
        }
    }
}