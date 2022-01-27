using GVRP.Module.Players.Db;
using MySql.Data.MySqlClient;
using System;

namespace GVRP.Module.PlayerLoginSecure
{
    public class PlayerLoginSecureModule : Module<PlayerLoginSecureModule>
    {
        public override void OnPlayerLoadData(DbPlayer dbPlayer, MySqlDataReader reader)
        {
            try
            {

            }
            catch (Exception e)
            {
                Logging.Logger.SaveToDbLog(e.ToString());
            }
        }
    }
}
