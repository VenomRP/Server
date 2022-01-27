using GVRP.Module.Configurations;

namespace GVRP.Module.Players
{
    public static class PlayerLoginDataValidationModule
    {
        public static int FreigeschaltetGroupId = 63;

        public static void SyncUserBanToForum(int forumId)
        {
            // Remove Freigeschaltet Gruppe
            if (!Configuration.Instance.DevMode)
                MySQLHandler.ExecuteForum($"DELETE FROM wcf1_user_to_group WHERE userID = '{forumId}' AND groupID = '63'");
        }

        public static bool HasValidForumAccount(int forumid)
        {
            if (Configuration.Instance.DevMode)
                return true;


            return true;
        }
    }
}
