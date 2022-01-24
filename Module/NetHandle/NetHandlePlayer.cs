using GTANetworkAPI;

namespace GVRP
{
    public static class NetHandlePlayer
    {
        public static Player ToPlayer(this NetHandle netHandle)
        {
            return NAPI.Player.GetPlayerFromHandle(netHandle);
        }
    }
}