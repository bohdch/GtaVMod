using System;
using GTANetworkAPI;

namespace GtaVMod.Exceptions
{
    public static class HandleException
    {
        public static void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                NAPI.Util.ConsoleOutput($"[ERROR] Exception occurred: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
