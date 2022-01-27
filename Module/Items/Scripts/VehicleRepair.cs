using GTANetworkAPI;
using GVRP.Handler;
using GVRP.Module.Chat;
using GVRP.Module.Players.Db;
using GVRP.Module.Vehicles;
using System.Threading.Tasks;

namespace GVRP.Module.Items.Scripts
{
    public static partial class ItemScript
    {
        public static async Task<bool> VehicleRepair(DbPlayer iPlayer, ItemModel ItemData)
        {

            if (iPlayer.Player.IsInVehicle) return false;

            //Items.Instance.UseItem(ItemData.id, iPlayer);
            var closestVehicle = VehicleHandler.Instance.GetClosestVehicle(iPlayer.Player.Position, 3);
            if (closestVehicle != null)
            {

                iPlayer.PlayAnimation(
                    (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "mini@repair", "fixing_a_ped");
                iPlayer.Player.TriggerEvent("freezePlayer", true);
                iPlayer.SetData("userCannotInterrupt", true);

                Chats.sendProgressBar(iPlayer, 20000);
                await Task.Delay(20000);

                iPlayer.ResetData("userCannotInterrupt");
                iPlayer.Player.TriggerEvent("freezePlayer", false);
                NAPI.Player.StopPlayerAnimation(iPlayer.Player);

                if (closestVehicle.entity.Position.DistanceTo(iPlayer.Player.Position) > 10) return false;

                closestVehicle.Repair();
                return true;
            }

            return false;
        }
    }
}