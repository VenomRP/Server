using GTANetworkAPI;

namespace GVRP
{
    public class Teamspeak
    {
        public static void ChangeVoiceRange(Player player, float range = 15.0f)
        {
            player.SetSharedData("VOICE_RANGE", range);
        }

        public static void Connect(Player player, string characterName)
        {
            player.TriggerEvent("ConnectTeamspeak");
        }
    }
}