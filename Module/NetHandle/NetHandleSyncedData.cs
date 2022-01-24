using GTANetworkAPI;

namespace GVRP
{
    public static class NetHandleSyncedData
    {   
        public static void RemoveEntityDataWhenExists(this Entity entity, string key)
        {
            if (entity.HasSharedData(key))
            {
                entity.ResetSharedData(key);
            }
        }
        
        public static void RemoveEntityDataWhenExists(this Player client, string key)
        {
            if (client.HasSharedData(key))
            {
                client.ResetSharedData(key);
            }
        }
    }
}