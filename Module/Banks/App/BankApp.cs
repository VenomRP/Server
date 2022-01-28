using GVRP.Module.ClientUI.Apps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using GVRP.Module.Business.Tasks;
using GVRP.Module.Banks.BankHistory;
using GTANetworkAPI;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;
using GVRP.Handler;
using GVRP.Module.Business;
using GVRP.Module.ClientUI.Windows;
using GVRP.Module.Gangwar;
using GVRP.Module.Logging;
using GVRP.Module.NSA;

using GVRP.Module.Players.Windows;
using GVRP.Module.Tattoo;
using GVRP.Module.Teams;
using GVRP.Module.Teams.Shelter;

namespace nexus.Module.Banks.App
{
    class BankApp : SimpleApp
    {
        public BankApp() : base("BankApp")
        {
        }



        public static DiscordHandler Discord = new DiscordHandler();


        [RemoteEvent]
        public void requestBankAppOverview(Player player)
        {
            var iPlayer = player.GetPlayer();
            if (iPlayer == null || !iPlayer.IsValid()) return;

            Console.WriteLine("BANKINGAPP: " + iPlayer.bank_money[0]);

            player.TriggerEvent("updateBankingapp", iPlayer.bank_money[0], NAPI.Util.ToJson(iPlayer.BankHistory));

        }

        [RemoteEvent]
        public void bankingAppTransfer(Player player, string name, int amount)
        {
            var iPlayer = player.GetPlayer();
            if (iPlayer == null || !iPlayer.IsValid()) return;


            DbPlayer targetPlayer = Players.Instance.FindPlayer(name);

            if (targetPlayer != null && targetPlayer.IsValid() && targetPlayer != iPlayer)
            {
                if (amount <= 0) return;
                if (iPlayer.TakeBankMoney(amount))
                {
                    targetPlayer.GiveBankMoney(amount);
                    iPlayer.SendNewNotification(
                        "Sie haben " + amount + "$ an " + targetPlayer.GetName() + " ueberwiesen.");
                    targetPlayer.SendNewNotification(
                        iPlayer.GetName() + " hat ihnen " + amount + "$ ueberwiesen.");
                    Discord.SendMessage($"{iPlayer.Player.Name} hat an den Spieler : ({targetPlayer.Player.Name}) den Betrag : ({amount}) überwiesen! (Handy)", "BANK-LOG", DiscordHandler.Channels.BANKING);

                    // Bankhistory
                    targetPlayer.AddPlayerBankHistory(amount, "Ueberweisung von " + iPlayer.Player.Name);
                    iPlayer.AddPlayerBankHistory(-amount, "Ueberweisung an " + targetPlayer.Player.Name);
                    GiveMoneyWindow.SaveToPayLog(iPlayer.Id.ToString(), targetPlayer.Id.ToString(), amount, TransferType.ÜBERWEISUNG);
                    return;
                }
            }
            else
            {

                iPlayer.SendNewNotification("Spieler nicht gefunden!");
                return;
            }
            
        }
    }


    

}
