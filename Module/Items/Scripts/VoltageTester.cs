using GVRP.Module.Houses;
using GVRP.Module.Players.Db;
using System.Linq;
using System.Threading.Tasks;

namespace GVRP.Module.Items.Scripts
{
    public static partial class ItemScript
    {
        public static async Task<bool> VoltageTest(DbPlayer iPlayer, ItemModel ItemData)
        {
            if (iPlayer.Player.IsInVehicle || iPlayer.TeamId != (int)teams.TEAM_FIB) return false;

            HousesVoltage housesVoltage = HousesVoltageModule.Instance.GetAll().Values.ToList().Where(hv => hv.Position.DistanceTo(iPlayer.Player.Position) < 5.0f).FirstOrDefault();

            if (housesVoltage == null) return false;

            Module.Menu.MenuManager.Instance.Build(GVRP.Module.Menu.PlayerMenu.VoltageMenu, iPlayer).Show(iPlayer);
            return true;
        }

    }
}