using GTANetworkAPI;
using GVRP.Module.Players.Db;
using System.Collections.Generic;

namespace GVRP.Module.Players.Ranks
{
    public static class PlayerIgnoreFeature
    {
        public static bool HasFeatureIgnored(this Player client, string name)
        {
            DbPlayer iPlayer = client.GetPlayer();
            if (iPlayer == null || !iPlayer.IsValid()) return false;

            if (!iPlayer.HasData("ignored_features")) return false;
            HashSet<string> features = iPlayer.GetData("ignored_features");
            return features.Contains(name);
        }

        public static void SetFeatureIgnored(this Player client, string name)
        {

            DbPlayer iPlayer = client.GetPlayer();
            if (iPlayer == null || !iPlayer.IsValid()) return;

            HashSet<string> features;
            if (!iPlayer.HasData("ignored_features"))
            {
                features = new HashSet<string>();
                iPlayer.SetData("ignored_features", features);
            }
            else
            {
                features = iPlayer.GetData("ignored_features");
            }

            if (features.Contains(name)) return;
            features.Add(name);
        }

        public static void RemoveFeatureIgnored(this Player client, string name)
        {
            DbPlayer iPlayer = client.GetPlayer();
            if (iPlayer == null || !iPlayer.IsValid()) return;

            if (!iPlayer.HasData("ignored_features")) return;
            HashSet<string> features = iPlayer.GetData("ignored_features");
            if (!features.Contains(name)) return;
            features.Remove(name);
        }
    }
}