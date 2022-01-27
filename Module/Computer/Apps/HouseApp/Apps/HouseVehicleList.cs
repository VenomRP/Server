using GTANetworkAPI;
using GVRP.Module.ClientUI.Apps;
using GVRP.Module.Houses;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;

namespace GVRP.Module.Computer.Apps.HouseApp.Apps
{
    public class HouseVehicleList : SimpleApp
    {

        public HouseVehicleList() : base("HouseVehicleList")
        {

        }

        [RemoteEvent]
        public void requestHouseVehicles(Player client)
        {
            DbPlayer dbPlayer = client.GetPlayer();
            if (dbPlayer == null || !dbPlayer.IsValid())
                return;

            if (dbPlayer.ownHouse[0] == 0)
            {
                dbPlayer.SendNewNotification("Du besitzt kein Haus.");
                return;
            }
            House house = HouseModule.Instance.GetByOwner(dbPlayer.Id);
            if (house == null) return;

            TriggerEvent(client, "responseHouseVehicles", NAPI.Util.ToJson(HouseAppFunctions.GetVehiclesForHouseByPlayer(dbPlayer, house)));
        }

        [RemoteEvent]
        public void dropHouseVehicle(Player client, int vehicleId)
        {
            DbPlayer dbPlayer = client.GetPlayer();
            if (dbPlayer == null || !dbPlayer.IsValid())
                return;

            MySQLHandler.ExecuteAsync($"UPDATE vehicles SET garage_id = 1 WHERE id = '{vehicleId}'");
            dbPlayer.SendNewNotification($"Du hast das Fahrzeug mit der ID {vehicleId} erfolgreich aus deiner Hausgarage entfernt.");
        }
    }
}
