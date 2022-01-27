using GTANetworkAPI;
using GVRP.Module.ClientUI.Apps;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;
using static GVRP.Module.Computer.Apps.SupportVehicleApp.SupportVehicleFunctions;

namespace GVRP.Module.Computer.Apps.SupportVehicleApp.Apps
{
    class SupportVehicleList : SimpleApp
    {
        public SupportVehicleList() : base("SupportVehicleList") { }

        [RemoteEvent]
        public async void requestSupportVehicleList(Player client, int owner)
        {

            DbPlayer iPlayer = client.GetPlayer();
            if (iPlayer == null || !iPlayer.IsValid()) return;

            VehicleCategory category = VehicleCategory.ALL;
            var vehicleData = SupportVehicleFunctions.GetVehicleData(category, owner);

            var vehicleDataJson = NAPI.Util.ToJson(vehicleData);
            TriggerEvent(client, "responseVehicleList", vehicleDataJson);

        }
    }
}
