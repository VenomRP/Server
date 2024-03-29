﻿using GTANetworkAPI;
using GVRP.Module.ClientUI.Components;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;
using GVRP.Module.Players.Windows;
using System.Linq;

namespace GVRP.Module.Kasino
{
    public class KasinoDiceModule : SqlModule<KasinoDiceModule, KasinoDice, uint>
    {
        public string DiceString = "Würfelspiel";

        protected override string GetQuery()
        {
            return "SELECT * FROM `kasino_dice`";
        }

        public override void OnTenSecUpdate()
        {

        }


        public override bool OnKeyPressed(DbPlayer dbPlayer, Key key)
        {
            if (key != Key.E) return false;

            KasinoDice kasinoDice = GetClosest(dbPlayer);
            if (kasinoDice == null) return false;

            if (!dbPlayer.Rank.CanAccessFeature("casino") && !KasinoModule.Instance.CasinoGuests.Contains(dbPlayer)) return true;

            if (!kasinoDice.IsInGame)
            {
                dbPlayer.SetData("casino_dice", kasinoDice); // can u go to the function where it loads the images yes
                StartKasinoDice(dbPlayer, kasinoDice);

            }
            else
            {
                dbPlayer.SendNewNotification("Die Runde läuft noch!", PlayerNotification.NotificationType.CASINO, DiceString);
                return false;
            }




            return true;
        }

        public void StartKasinoDice(DbPlayer iPlayer, KasinoDice kasinoDice)
        {
            NAPI.Task.Run(() => ComponentManager.Get<TextInputBoxWindow>().Show()(
                iPlayer,
                new TextInputBoxWindowObject()
                {  //thats other thing its wurfel not casino | ok let me fix this anyways
                    Title = $"Würfelrunde ({kasinoDice.MinPrice} $ - {kasinoDice.MaxPrice} $)",
                    Callback = "StartDiceGame",
                    Message = "Gib einen Einsatz ein, den jeder Teilnehmer setzen muss."
                }
              )
           );
        }



        public KasinoDice GetClosest(DbPlayer dbPlayer)
        {
            return GetAll().FirstOrDefault(kasinoDice => kasinoDice.Value.Position.DistanceTo(dbPlayer.Player.Position) < kasinoDice.Value.Radius).Value;
        }
    }
}
