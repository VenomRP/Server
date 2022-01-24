using GTANetworkAPI;

namespace GVRP.Module.GTAN
{
    public static class EntityGTAN
    {
        public static bool TryData<T>(this Entity entity, string key, out T value)
        {
            var HasData = entity.HasData(key);
            value = HasData ? entity.GetData<T>(key) : default(T);
            return HasData;
        }
    }
}