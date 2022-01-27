using GTANetworkAPI;
using GVRP.Module.Injury;
using GVRP.Module.Logging;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;
using System;

namespace GVRP.Module.AsyncEventTasks
{
    public static partial class AsyncEventTasks
    {
        public static void PlayerWeaponSwitchTask(Player c, WeaponHash oldgun, WeaponHash newWeapon)
        {
            try
            {
                DbPlayer dbPlayer = c.GetPlayer();

                if (dbPlayer == null || !dbPlayer.IsValid(true))
                    return;

                if (oldgun == null) return;
                if (newWeapon == null) return;
                if (c == null) return;
                if (c.GetPlayer().isInjured())
                {
                    NAPI.Player.SetPlayerCurrentWeapon(c, WeaponHash.Unarmed);
                    return;
                }
                if (newWeapon == WeaponHash.Unarmed) return;



                NAPI.Player.SetPlayerCurrentWeapon(c, newWeapon);
                //NAPI.Player.SetPlayerCurrentWeaponAmmo(c, 9999);


                c.TriggerEvent("client:weaponSwap");
                return;
            }
            catch (Exception ex)
            {
                Logger.Crash(ex);
            }
        }
    }
}
