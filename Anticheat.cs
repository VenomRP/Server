using System.Collections.Generic;
using GTANetworkAPI;
using GVRP.Module.Logging;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;
using GVRP.Module.Vehicles;


namespace GVRP.Anticheat
{
    public static class Anticheat
    {

        /*public static void ValidePlayerComponents(Player player)

        {

            var comps = player.GetAllWeaponComponents(player.CurrentWeapon);

            // Defaultweapons hasent any components so....
            foreach (var comp in comps)
            {
                Players.Instance.SendMessageToAuthorizedUsers("anticheat",
                    $"ANTICHEAT (WEAPON CLIP HACK) {player.Name} :: {comp}");
            }
        }*/

        private static readonly List<WeaponHash> ForbiddenWeapons =
        new List<WeaponHash>(new[] {
            WeaponHash.Railgun, WeaponHash.Rpg, WeaponHash.Minigun, WeaponHash.Proximine, WeaponHash.Stickybomb, WeaponHash.Pipebomb, WeaponHash.Rpg, (WeaponHash)0xBFE256D4, WeaponHash.Snspistol, WeaponHash.Marksmanpistol, WeaponHash.Revolver, (WeaponHash)0xCB96392F, (WeaponHash)0x97EA20B8, (WeaponHash)0xAF3696A1, (WeaponHash)0x917F6C8C, (WeaponHash)0x57A4368C, (WeaponHash)0x78A97CD0, (WeaponHash)0x476BF155, (WeaponHash)0x12E82D3D, (WeaponHash)0x9D61E50F, (WeaponHash)0x555AF99A, (WeaponHash)0x394F415C, (WeaponHash)0xFAD1F1C9, (WeaponHash)0x969C3D67, (WeaponHash)0x84D6FAFD, (WeaponHash)0xC78D71B4, (WeaponHash)0xDBBD7280, (WeaponHash)0xA914799, (WeaponHash)0x6A6C02E0, (WeaponHash)0x4DD2DC56, (WeaponHash)0x63AB0442, (WeaponHash)0x0781FE4A, (WeaponHash)0xB62D1F67, (WeaponHash)0xDB26713A, WeaponHash.Grenade, WeaponHash.Bzgas, WeaponHash.Molotov, WeaponHash.Stickybomb, WeaponHash.Pipebomb, WeaponHash.Smokegrenade
        });

        public static void CheckForbiddenWeapons(DbPlayer dbPlayer, WeaponHash hash)
        {
            var currW = dbPlayer.Player.CurrentWeapon;

            if (!ForbiddenWeapons.Contains(currW) ||  dbPlayer.Rank.Id < 4 && dbPlayer.Rank.Id > 7 || dbPlayer.IsInAdminDuty()) return;
            GVRP.Module.Chat.Chats.SendGlobalMessage($"Der Spieler {dbPlayer.Player.Name} wurde vom Anticheat gebannt.", Module.Chat.Chats.COLOR.RED, Module.Chat.Chats.ICON.GLOB);

            //DBLogging.LogAdminAction(player, dbPlayer.Player.Name, adminLogTypes.perm, "Community-Ausschluss", 0, Devmode);
            Main.Discord.SendMessage($"Der Spieler {dbPlayer.Player.Name} wurde vom Anticheat gebannt. ({currW})", "XCM-LOG", Handler.DiscordHandler.Channels.ANTICHEAT);

            dbPlayer.warns[0] = 3;
            SocialBanHandler.Instance.AddEntry(dbPlayer.Player);
            dbPlayer.Player.SendNotification("Permanenter Ausschluss!");
            PlayerLoginDataValidationModule.SyncUserBanToForum(dbPlayer.ForumId);
            dbPlayer.Player.Kick("Permanenter Ausschluss!");
        }
    }
}