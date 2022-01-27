using GTANetworkAPI;
using GVRP.Handler;
using GVRP.Module.Injury;
using GVRP.Module.Logging;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;
using GVRP.Module.Vehicles;
using System;


namespace GVRP.Module
{
    public class WeaponSwitchModule : Module<WeaponSwitchModule>
    {
        public static DiscordHandler Discord = new DiscordHandler();

        [ServerEvent(Event.PlayerWeaponSwitch)]
        public void playerWeaponSwitch(Player c, WeaponHash oldWeapon, WeaponHash newWeapon)
        {
            try
            {
                DbPlayer dbPlayer = c.GetPlayer();

                if (dbPlayer == null || !dbPlayer.IsValid(true))
                    return;

                if (oldWeapon == null) return;
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