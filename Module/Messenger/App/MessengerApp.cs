using GTANetworkAPI;
using GVRP.Module.ClientUI.Apps;

namespace GVRP.Module.Messenger.App
{
    public class MessengerApp : SimpleApp
    {
        public MessengerApp() : base("MessengerApp")
        {
        }

        [RemoteEvent]
        public void sendMessage(Player client, uint number, string messageContent)
        {
        }

        [RemoteEvent]
        public void forwardMessage(Player client, uint number, uint messageId)
        {
            // Forwars selected message in "original" and fake-proof. TBD later.
        }
    }
}