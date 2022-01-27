using GTANetworkAPI;
using GVRP.Module.Items;
using System;

namespace GVRP.Module.DropItem
{
    public class ItemHeap
    {
        public Container Container { get; set; }
        public DateTime CreateDateTime { get; set; }
        public ColShape ColShape { get; set; }
        public Marker Marker { get; set; }

        public ItemHeap()
        {

        }
    }
}
