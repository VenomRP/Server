using GTANetworkAPI;
using GVRP.Module.Players;
using System.Text.RegularExpressions;

namespace GVRP.Module.Clothes.Outfits
{
    public class OutfitsEvents : Script
    {
        [RemoteEvent]
        public void SaveOutfit(Player player, string returnstring)
        {
            var dbPlayer = player.GetPlayer();
            if (dbPlayer == null) return;

            if (!Regex.IsMatch(returnstring, @"^[a-zA-Z ]+$"))
            {
                dbPlayer.SendNewNotification("Dieser Name ist nicht gueltig!");
                return;
            }

            Outfit outfit = new Outfit()
            {
                PlayerId = dbPlayer.Id,
                Name = returnstring,
                Clothes = dbPlayer.Character.Clothes,
                Props = dbPlayer.Character.EquipedProps
            };

            OutfitsModule.Instance.AddOutfit(dbPlayer, outfit);
            dbPlayer.SendNewNotification("Outfit gespeichert!");
        }
    }
}
