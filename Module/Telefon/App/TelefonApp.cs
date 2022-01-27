using GVRP.Module.ClientUI.Apps;
using GVRP.Module.Players.Db;

namespace GVRP.Module.Telefon.App
{
    public class TelefonApp : SimpleApp
    {
        public TelefonApp() : base("Telefon")
        {
        }

        public DbPlayer GetPlayerByPhoneNumber(int p_PhoneNumber)
        {
            foreach (var l_Player in Players.Players.Instance.GetValidPlayers())
            {
                if ((int)l_Player.handy[0] != p_PhoneNumber)
                    continue;

                return l_Player;
            }

            return null;
        }
    }
}