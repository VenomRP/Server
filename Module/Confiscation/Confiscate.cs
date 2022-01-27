using System;

namespace GVRP.Module.Confiscation
{
    public class Confiscate
    {
        public uint Id { get; }
        public DateTime ConfiscatedTime { get; set; }
        public DateTime FreeTime { get; set; }
        public string ConfiscatName { get; set; }
        public string ConfiscatReason { get; set; }
    }
}
