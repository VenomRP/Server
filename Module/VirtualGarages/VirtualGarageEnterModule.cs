using System;

namespace GVRP.Module.VirtualGarages
{
    public class VirtualGarageEnterModule : SqlModule<VirtualGarageEnterModule, VirtualGarageEnter, uint>
    {
        public override Type[] RequiredModules()
        {
            return new[] { typeof(VirtualGarageModule) };
        }

        protected override string GetQuery()
        {
            return "SELECT * FROM `virtual_garages_enters`;";
        }
    }
}
