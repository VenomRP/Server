using GTANetworkAPI;
using GVRP.Module.Clothes;
using GVRP.Module.Customization;
using GVRP.Module.Players;

namespace GVRP.Module.AsyncEventTasks
{
    public static partial class AsyncEventTasks
    {
        public static void ExitColShapeTask(ColShape shape, Player player)
        {
            var iPlayer = player.GetPlayer();
            if (iPlayer == null) return;
            if (!iPlayer.IsValid()) return;

            if (Modules.Instance.OnColShapeEvent(iPlayer, shape, ColShapeState.Exit)) return;

            if (shape.HasData("clothShopId"))
            {
                ClothModule.Instance.ResetClothes(iPlayer);
                if (iPlayer.HasData("clothShopId"))
                {
                    iPlayer.ApplyCharacter();
                    iPlayer.ResetData("clothShopId");
                }
            }

            if (shape.HasData("teamWardrobe"))
            {
                ClothModule.Instance.ResetClothes(iPlayer);
                if (iPlayer.HasData("teamWardrobe"))
                {
                    iPlayer.ResetData("teamWardrobe");
                }
            }

            if (shape.HasData("ammunationId"))
            {
                if (iPlayer.HasData("ammunationId"))
                {
                    iPlayer.ResetData("ammunationId");
                }
            }
            if (shape.HasData("name_change"))
            {
                if (iPlayer.HasData("name_change"))
                {
                    iPlayer.ResetData("name_change");
                }
            }

            if (shape.HasData("garageId"))
            {
                if (iPlayer.HasData("garageId"))
                {
                    iPlayer.ResetData("garageId");
                }
            }

            if (shape.HasData("bankId"))
            {
                if (iPlayer.HasData("bankId"))
                {
                    iPlayer.ResetData("bankId");
                }
            }

            if (shape.HasData("ArmoryId"))
            {
                if (iPlayer.HasData("ArmoryId"))
                {
                    iPlayer.ResetData("ArmoryId");
                }
            }
        }
    }
}
