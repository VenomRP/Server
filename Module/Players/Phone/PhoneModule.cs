using GVRP.Module.Players.Db;
using GVRP.Module.Players.Phone.Apps;
using GVRP.Module.Players.Phone.Contacts;
using System.Collections.Generic;

namespace GVRP.Module.Players.Phone
{
    public class PhoneModule : Module<PhoneModule>
    {
        public static Dictionary<int, int> ActivePhoneCalls = new Dictionary<int, int>();

        protected override bool OnLoad()
        {
            ActivePhoneCalls = new Dictionary<int, int>();
            return base.OnLoad();
        }

        public override void OnPlayerConnected(DbPlayer dbPlayer)
        {
            dbPlayer.PhoneContacts = new PhoneContacts(dbPlayer.Id);
            dbPlayer.PhoneApps = new PhoneApps(dbPlayer);
        }

    }
}