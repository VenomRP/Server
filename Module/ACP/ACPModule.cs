using System.Threading.Tasks;

namespace GVRP.Module.ACP
{
    public sealed class ACPModule : Module<ACPModule>
    {
        public override bool Load(bool reload = false)
        {
            return true;
        }


        enum ActionType
        {
            KICK = 0,
            WHISPER = 1,
            SETMONEY = 2,
        }

        public override async Task OnTenSecUpdateAsync()
        {



        }
    }
}
