using GTANetworkAPI;
using GVRP.Module.ClientUI.Apps;
using GVRP.Module.LeitstellenPhone;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;
using System;
using System.Threading.Tasks;

namespace GVRP.Module.Computer.Apps.VehicleClawUebersichtApp.Apps
{
    public class VehicleClawUebersichtApp : SimpleApp
    {
        public VehicleClawUebersichtApp() : base("VehicleClawUebersichtApp") { }
        public enum SearchType
        {
            PLAYERNAME = 0,
            VEHICLEID = 1
        }


        [RemoteEvent]
        public async Task requestVehicleClawOverviewByPlayerName(Player client, String playerName)
        {
            await HandleVehicleClawOverview(client, playerName, SearchType.PLAYERNAME);
        }

        [RemoteEvent]
        public async Task requestVehicleClawOverviewByVehicleId(Player client, int vehicleId)
        {
            await HandleVehicleClawOverview(client, vehicleId.ToString(), SearchType.VEHICLEID);

        }


        private async Task HandleVehicleClawOverview(Player p_Client, String information, SearchType type)
        {
            DbPlayer p_DbPlayer = p_Client.GetPlayer();
            if (p_DbPlayer == null || !p_DbPlayer.IsValid())
                return;

            if (LeitstellenPhoneModule.Instance.GetByAcceptor(p_DbPlayer) == null)
            {
                p_DbPlayer.SendNewNotification("Sie müssen als Leitstelle angemeldet sein", PlayerNotification.NotificationType.ERROR);
                return;
            }

            var l_Overview = VehicleClawUebersichtFunctions.GetVehicleClawByIdOrName(p_DbPlayer, type, information);
            TriggerEvent(p_Client, "responseVehicleClawOverview", NAPI.Util.ToJson(l_Overview));
        }

    }
}
