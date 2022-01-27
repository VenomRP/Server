using GVRP.Module.Players;
using GVRP.Module.Players.Db;
using System.Threading.Tasks;

namespace GVRP.Module.Items.Scripts
{
    public static partial class ItemScript
    {
        public static async Task<bool> Drink(DbPlayer iPlayer, ItemModel ItemData)
        {
            if (!iPlayer.CanInteract() || iPlayer.Player.IsInVehicle) return false;

            iPlayer.PlayAnimation((int)(AnimationFlags.AllowPlayerControl | AnimationFlags.Loop | AnimationFlags.OnlyAnimateUpperBody), "amb@world_human_drinking@coffee@male@idle_a", "idle_a");
            iPlayer.SetCannotInteract(true);
            await Task.Delay(5000);
            iPlayer.SetCannotInteract(false);
            iPlayer.StopAnimation();
            return true;
        }
    }
}