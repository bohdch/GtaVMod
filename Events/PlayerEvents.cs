using GTANetworkAPI;
using Microsoft.Extensions.DependencyInjection;
using GtaVMod.Constants;
using GtaVMod.Interfaces;

namespace GtaVMod.Events
{
    public class PlayerEvents : Script
    {
        private readonly IAccountService _accountService;

        public PlayerEvents()
        {
            _accountService = ServicesContainer.ServiceProvider.GetService<IAccountService>();
        }

        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            NAPI.Util.ConsoleOutput($"[INFO] Player connected: {player.Name} (ID: {player.Handle.Value}, IP: {player.Address})");
            player.SendChatMessage($"~g~Welcome to the RageMP Server!");

            if (_accountService.AccountExists(player))
                player.SendChatMessage("~w~Your account is already registered on the server. Please use /login for auth.");
            else
                player.SendChatMessage("~w~Your account isn't registered on the server. Please use /register for registration.");
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Player player, DisconnectionType type, string reason)
        {
            NAPI.Util.ConsoleOutput($"[INFO] Player disconnected: {player.Name} (ID: {player.Handle.Value})");
            _accountService.UpdatePlayerPosition(player.Name, player.Position.X, player.Position.Y, player.Position.Z);
        }

        [ServerEvent(Event.PlayerSpawn)]
        public void OnPlayerSpawn(Player player)
        {
            player.Position = PlayerConstants.DefaultSpawnPosition;
        }
    }
}
