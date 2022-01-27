using GVRP.Module.Configurations;
using GVRP.Module.Players.Db;
using GVRP.Module.Vehicles.Data;
using MySql.Data.MySqlClient;

namespace GVRP.Module.VehicleTax
{
    public sealed class VehicleTaxModule : Module<VehicleTaxModule>
    {
        public override void OnPlayerLoadData(DbPlayer dbPlayer, MySqlDataReader reader)
        {
            dbPlayer.VehicleTaxSum = reader.GetInt32("tax_sum");
        }

        public override void OnFiveMinuteUpdate()
        {

        }

        public static int GetPlayerVehicleTaxesForGarages(DbPlayer iPlayer)
        {
            int tax = 0;

            string query = $"SELECT * FROM `vehicles` WHERE `owner` = '{iPlayer.Id}' AND `inGarage` = '1' AND `registered` = '1';";

            using (var conn = new MySqlConnection(Configuration.Instance.GetMySqlConnection()))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = @query;
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var modelId = reader.GetUInt32("model");
                            var data = VehicleDataModule.Instance.GetDataById(modelId);
                            if (data == null) continue;
                            tax = tax + data.Tax;
                        }
                    }
                }
            }
            return tax;
        }
    }
}