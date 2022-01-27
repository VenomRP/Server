using GTANetworkAPI;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;

namespace GVRP.Module.Menu
{

    public static class DialogMigrator
    {
        public static void OpenUserMenu(DbPlayer iPlayer, uint MenuID, bool nofreeze = false)
        {
            if (iPlayer.WatchMenu > 0)
            {
                //CloseUserMenu(iPlayer.Player, iPlayer.WatchMenu);
            }

            ShowMenu(iPlayer.Player, MenuID);
            iPlayer.WatchMenu = MenuID;
        }

        public static void CloseUserMenu(Player player, uint MenuID, bool noHide = false)
        {
            DbPlayer iPlayer = player.GetPlayer();
            if (iPlayer == null) return;
            if (!noHide) HideMenu(player, MenuID);
            /*if (iPlayer.Freezed == false)
            {
                player.FreezePosition = false;
            }*/

            iPlayer.WatchMenu = 0;
        }

        public static void CreateMenu(Player player, uint menuid, string name = "", string description = "")
        {
            player.TriggerEvent("componentServerEvent", "NativeMenu", "createMenu", name, description);
        }

        public static void AddMenuItem(Player player, uint menuid, string label, string description)
        {
            player.TriggerEvent("componentServerEvent", "NativeMenu", "addItem", label, description);
        }

        public static void ShowMenu(Player player, uint menuid)
        {
            player.TriggerEvent("componentServerEvent", "NativeMenu", "show", menuid);
        }

        private static void HideMenu(Player player, uint menuid)
        {
            player.TriggerEvent("componentServerEvent", "NativeMenu", "hide");
        }

        public static void CloseUserDialog(Player player, uint dialogid)
        {
            var iPlayer = player.GetPlayer();
            iPlayer.watchDialog = 0;
            player.TriggerEvent("deleteDialog");
            iPlayer.Player.TriggerEvent("freezePlayer", false);
            //player.Freeze(false);
        }

    }
}
