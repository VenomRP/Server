using GTANetworkAPI;
using System.Collections.Generic;

namespace GVRP.Module.Clothes.Character
{
    public class Character
    {
        public uint PlayerId;

        public Dictionary<int, uint> Clothes;

        public Dictionary<int, bool> ActiveClothes;

        public Dictionary<int, bool> ActiveProps;

        public Dictionary<int, uint> EquipedProps;

        public List<uint> Wardrobe;

        public List<uint> Props;

        public PedHash Skin { get; set; }

    }
}