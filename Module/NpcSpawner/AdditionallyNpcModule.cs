namespace GVRP.Module.NpcSpawner
{
    public class AdditionallyNpcModule : SqlModule<AdditionallyNpcModule, AdditionallyNpc, uint>
    {
        protected override string GetQuery()
        {
            return "SELECT * FROM `additionally_npcs`;";
        }
    }
}
