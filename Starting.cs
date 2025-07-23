using GTANetworkAPI;

namespace GtaVMod
{
    public class Starting : Script
    {
        public Starting() : base()
        {
            NAPI.Util.ConsoleOutput("[INFO] Initializing services...");
            ServicesContainer.Init();
        }
    }
}
