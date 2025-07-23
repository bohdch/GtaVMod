using GTANetworkAPI;
using GtaVMod.Constants;

namespace GtaVMod.Helpers
{
    public static class PlayerAuthHelper
    {
        public static void SetLoggedIn(Player player, bool value)
        {
            player.SetData(PlayerConstants.LoggedInKey, value);
        }

        public static bool IsLoggedIn(Player player)
        {
            if (player.HasData(PlayerConstants.LoggedInKey) && player.GetData<bool>(PlayerConstants.LoggedInKey))
                return true;

            return false;
        }
    }
}
