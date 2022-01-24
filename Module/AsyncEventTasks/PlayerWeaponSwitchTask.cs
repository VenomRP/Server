using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GVRP.Module.Armory;
using GVRP.Module.Banks;
using GVRP.Module.Clothes;
using GVRP.Module.Houses;
using GVRP.Module.Logging;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;
using GVRP.Module.Teams;
using GVRP.Module.Vehicles.Garages;
using GVRP.Module.Injury;

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
