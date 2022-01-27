using GTANetworkAPI;
using GVRP.Module.Players;
using GVRP.Module.Players.Db;

namespace GVRP.Module.Pet
{
    public sealed class PetModule : SqlModule<PetModule, PetData, uint>
    {
        protected override string GetQuery()
        {
            return "SELECT * FROM `pets`;";
        }

        protected override bool OnLoad()
        {
            return base.OnLoad();
        }

        public override void OnPlayerDisconnected(Player player, string reason)
        {
            var dbPlayer = player.GetPlayer();
            dbPlayer.RemovePet();
        }
    }
}