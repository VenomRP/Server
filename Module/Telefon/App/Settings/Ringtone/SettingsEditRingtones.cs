using GTANetworkAPI;
using GVRP.Module.ClientUI.Apps;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;
using GVRP.Module.Telefon.App.Settings.Ringtone;

namespace GVRP.Module.Telefon.App.Settings
{
    public class SettingsEditRingtones : SimpleApp
    {
        public SettingsEditRingtones() : base("SettingsEditRingtonesApp") { }


        [RemoteEvent]
        public void requestRingtoneList(Player player)
        {
            DbPlayer dbPlayer = player.GetPlayer();
            if (dbPlayer == null) return;
            TriggerEvent(player, "responseRingtoneList", RingtoneModule.Instance.getJsonRingtonesForPlayer(dbPlayer));

        }

        [RemoteEvent]
        public void saveRingtone(Player player, int ringtoneId)
        {
            DbPlayer dbPlayer = player.GetPlayer();
            if (dbPlayer == null) return;
            dbPlayer.ringtone = RingtoneModule.Instance.Get((uint)ringtoneId);
            dbPlayer.SaveRingtone();
        }

    }

}
