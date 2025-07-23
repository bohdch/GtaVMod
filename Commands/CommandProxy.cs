using GtaVMod.Helpers;
using System;
using GTANetworkAPI;

namespace GtaVMod.Commands
{
    public static class CommandProxy
    {
        public static void ExecuteIfLoggedIn(Player player, Action<Player> action)
        {
            if (!PlayerAuthHelper.IsLoggedIn(player))
            {
                player.SendChatMessage("~r~You must be logged in to use this command. Use /login to authenticate.");
                return;
            }

            action(player);
        }
    }
}
