﻿using GTANetworkAPI;
using GVRP.Handler;
using GVRP.Module.Logging;
using GVRP.Module.Players;

namespace GVRP.Module.Anticheat

{
    class AntiCheatEvents : Script
    {

        public static DiscordHandler Discord = new DiscordHandler();

        [RemoteEvent]
        public void __ragemp_cheat_detected(Player player, int cheatCode)
        {

            var dbPlayer = player.GetPlayer();
            if (dbPlayer == null) return;
            if (!dbPlayer.Player.Exists) { return; }

            string l_Cheat = "Cheat Engine";

            switch (cheatCode)
            {
                case 0:
                case 1:
                    l_Cheat = "Cheat Engine";
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    l_Cheat = "Externer Hack";
                    break;
                case 7:
                    l_Cheat = "Mod-Menü";
                    break;
                case 8:
                case 9:
                    l_Cheat = "Speed Hack";
                    break;
                case 11:
                    l_Cheat = "Nutzung von Sandboxie";
                    break;
                default:
                    break;
            }

            Discord.SendMessage($"{dbPlayer.Player.Name} hat ein Anticheat-Log ausgelöst! ({cheatCode})", "", DiscordHandler.Channels.ANTICHEAT);
            Logger.AddActionLogg(dbPlayer.Id, cheatCode);
            Players.Players.Instance.SendMessageToAuthorizedUsers("teamchat", $"Dringender Anticheat-Verdacht: {dbPlayer.Player.Name} ({l_Cheat}) gegeben.");


        }

        [RemoteEvent("server:Healkeydetection")]
        public void HealkeyDetection(Player player, int allowedhealth, int health)
        {
            return;
            var dbPlayer = player.GetPlayer();
            if (!dbPlayer.Player.Exists) { return; }

            Players.Players.Instance.SendMessageToAuthorizedUsers("teamchat", $"Dringender Anticheat-Verdacht: {dbPlayer.Player.Name} ({allowedhealth - health}).");
            Discord.SendMessage($"Dringender Anticheat-Verdacht: {dbPlayer.Player.Name} ({health - allowedhealth})", "", DiscordHandler.Channels.ANTICHEAT);
        }
    }
}
