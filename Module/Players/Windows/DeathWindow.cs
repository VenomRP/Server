using GTANetworkAPI;
using GVRP.Module.ClientUI.Windows;
using GVRP.Module.Players.Db;
using System;

namespace GVRP.Module.Players.Windows
{
    public class DeathWindow : Window<Func<DbPlayer, bool>>
    {
        private class ShowEvent : Event
        {
            public ShowEvent(DbPlayer dbPlayer) : base(dbPlayer)
            {
            }
        }

        public DeathWindow() : base("Death")
        {
        }

        public override Func<DbPlayer, bool> Show()
        {
            return player => OnShow(new ShowEvent(player));
        }

        public void closeDeathWindowS(Player client)
        {
            TriggerEvent(client, "closeDeathScreen");
        }
    }
}