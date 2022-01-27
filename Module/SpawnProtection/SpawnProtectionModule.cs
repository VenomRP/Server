using GVRP.Module.Players;
using GVRP.Module.Players.Db;
using GVRP.Module.Vehicles;
using System;

namespace GVRP.Module.SpawnProtection
{
    public sealed class SpawnProtectionModule : Module<SpawnProtectionModule>
    {
        public override bool Load(bool reload = false)
        {
            return true;
        }

        public override void OnPlayerFirstSpawn(DbPlayer dbPlayer)
        {
            // Set SpawnProtection
            dbPlayer.SetData("spawnProtectionSet", DateTime.Now);
            dbPlayer.Player.TriggerEvent("setSpawnProtection", true);
        }

        public override void OnTenSecUpdate()
        {
            foreach (DbPlayer dbPlayer in Players.Players.Instance.GetValidPlayers())
            {
                if (dbPlayer == null || !dbPlayer.IsValid()) return;

                if (dbPlayer.HasData("spawnProtectionSet"))
                {
                    DateTime spawnProtectionTime = dbPlayer.GetData("spawnProtectionSet");
                    if (spawnProtectionTime.AddSeconds(20) <= DateTime.Now)
                    {
                        dbPlayer.ResetData("spawnProtectionSet");
                        dbPlayer.Player.TriggerEvent("setSpawnProtection", false);
                    }
                }
            }
        }
    }
}