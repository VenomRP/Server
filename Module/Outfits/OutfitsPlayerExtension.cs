using GVRP.Module.Players.Db;

namespace GVRP.Module.Outfits
{
    public static class OutfitsPlayerExtension
    {
        public static void SetOutfit(this DbPlayer dbPlayer, OutfitTypes outfitType)
        {
            OutfitsModule.Instance.SetPlayerOutfit(dbPlayer, (int)outfitType);
        }
    }
}
