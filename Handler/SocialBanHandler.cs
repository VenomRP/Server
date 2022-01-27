using GTANetworkAPI;
using GVRP.Module.Configurations;
using MySql.Data.MySqlClient;

namespace GVRP
{
    public sealed class SocialBanHandler
    {
        public static SocialBanHandler Instance { get; } = new SocialBanHandler();

        private SocialBanHandler()
        {
        }

        public void AddEntry(Player player)
        {
            MySQLHandler.ExecuteAsync(
                $"INSERT INTO socialbans (Name) VALUES ('{player.SocialClubName}');");
        }

        public bool IsPlayerSocialBanned(Player player)
        {
            if (player == null || player.SocialClubName == "" || player.SocialClubName == null) return false;

            using (var conn = new MySqlConnection(Configuration.Instance.GetMySqlConnection()))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = $"SELECT * FROM socialbans WHERE Name = '{MySqlHelper.EscapeString(player.SocialClubName)}';";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return false;
                    }
                }
                conn.Close();
            }

            return false;
        }

        public bool IsPlayerWhitelisted(Player player)
        {
            if (player == null || player.Address == "" || player.Address == null) return false;

            using (var conn = new MySqlConnection(Configuration.Instance.GetMySqlConnection()))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = $"SELECT * FROM ipwhitelist WHERE ip = '{MySqlHelper.EscapeString(player.Address)}';";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return true;
                    }
                }
                conn.Close();
            }

            return false;
        }

        public void DeleteEntry(Player player)
        {
            var query =
                $"DELETE FROM socialbans WHERE Name = '{player.SocialClubName}';";
            MySQLHandler.ExecuteAsync(query);
        }

        public void DeleteTestEntry(string niger)
        {
            var query =
                $"DELETE FROM socialbans WHERE Name = '{niger}';";
            MySQLHandler.ExecuteAsync(query);
        }
    }
}