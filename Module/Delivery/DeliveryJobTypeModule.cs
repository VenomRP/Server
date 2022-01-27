using System;

namespace GVRP.Module.Delivery
{
    public class DeliveryJobTypeModule : SqlModule<DeliveryJobTypeModule, DeliveryJobType, uint>
    {
        public override Type[] RequiredModules()
        {
            return new[] { typeof(DeliveryJobModule) };
        }
        protected override string GetQuery()
        {
            return "SELECT * FROM `delivery_jobs_types`;";
        }


    }
}
