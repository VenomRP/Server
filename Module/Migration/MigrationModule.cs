using GVRP.Module.Configurations;
using System;

namespace GVRP.Module.Migration
{
    public class MigrationModule : Module<MigrationModule>
    {
        public override Type[] RequiredModules()
        {
            return new[] { typeof(ConfigurationModule) };
        }

        public override bool Load(bool reload = false)
        {
            return base.Load(reload);
        }
    }
}
