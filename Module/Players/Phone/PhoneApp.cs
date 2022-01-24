using GTANetworkAPI;
using System.Text.RegularExpressions;
using GVRP.Module.ClientUI.Apps;
using GVRP.Module.Players.Db;

namespace GVRP.Module.Players.Phone
{
    public class PhoneApp : SimpleApp
    {
        public PhoneApp() : base("PhoneApp")
        {
        }

        [RemoteEvent]
        public void requestPhoneContacts(Player player) 
        {
            var dbPlayer = player.GetPlayer();
            if (dbPlayer == null || !dbPlayer.IsValid()) return;
            player.TriggerEvent("responsePhoneContacts", dbPlayer.PhoneContacts.GetJson());
        }

        [RemoteEvent]
        public void updatePhoneContact(Player player, int oldNumber, int newNumber, string name)
        {
            var dbPlayer = player.GetPlayer();
            if (dbPlayer == null || !dbPlayer.IsValid()) return;
            if (oldNumber < 0 || oldNumber > 99999999) return;
            if (newNumber < 0 || newNumber > 99999999) return;
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9_#\s-]+$"))
            {
                dbPlayer.SendNewNotification("Kontakt konnte nicht aktualisiert werden!", notificationType:PlayerNotification.NotificationType.ERROR);
                return;
            }
            dbPlayer.PhoneContacts.Update((uint)oldNumber, (uint)newNumber, name);
        }

        [RemoteEvent]
        public void addPhoneContact(Player player, string name, int number)
        {
            var dbPlayer = player.GetPlayer();
            if (dbPlayer == null || !dbPlayer.IsValid()) return;
            if (number < 0 || number > 99999999) return;
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9_#\s-]+$"))
            {
                dbPlayer.SendNewNotification("Kontakt konnte nicht eingespeichert werden.", notificationType:PlayerNotification.NotificationType.ERROR);
                return;
            }

            dbPlayer.PhoneContacts.Add(name, (uint)number);
        }

        [RemoteEvent]
        public void delPhoneContact(Player player, int number)
        {
            var dbPlayer = player.GetPlayer();
            if (dbPlayer == null || !dbPlayer.IsValid()) return;
            if (number < 0 || number > 99999999) return;
            dbPlayer.PhoneContacts.Remove((uint)number);
        }
    }
}