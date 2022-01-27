namespace GVRP.Module.Delivery
{
    public class DeliveryJobSpawnpointModule : SqlModule<DeliveryJobSpawnpointModule, DeliveryJobSpawnpoint, uint>
    {
        protected override string GetQuery()
        {
            return "SELECT * FROM `delivery_jobs_spawnpoints`;";
        }


    }
}
