using GTANetworkAPI;
using GVRP.Module.Players;
using System;

namespace GVRP.Module.Jobs.Taxi
{
    public class TaxiEventHandler : Script
    {
        [RemoteEvent]
        public void resultTaxometer(Player client, double distance, int price)
        {
            var iPlayer = client.GetPlayer();
            if (iPlayer == null || !iPlayer.IsValid()) return;

            iPlayer.SendNewNotification(
                "Taxometer lief fuer " + distance + "km. Gesamtpreis: " + Math.Round(distance * price) +
                "$");
        }
    }
}