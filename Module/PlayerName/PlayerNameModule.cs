namespace GVRP.Module.PlayerName
{
    public class PlayerNameModule : SqlModule<PlayerNameModule, PlayerName, uint>
    {
        protected override string GetQuery()
        {
            return "SELECT * FROM `player`;";
        }
    }
}
