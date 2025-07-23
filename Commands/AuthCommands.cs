using GTANetworkAPI;
using Microsoft.Extensions.DependencyInjection;
using GtaVMod.Helpers;
using GtaVMod.Interfaces;

namespace GtaVMod.Commands
{
    public class AuthCommands : Script
    {
        private readonly IAccountService _accountService;

        public AuthCommands()
        {
            _accountService = ServicesContainer.ServiceProvider.GetService<IAccountService>();
        }

        [Command("login", "/login [password]")]
        public void Login(Player player, string password)
        {
            if (!ValidateAccount(player)) return;
            
            _accountService.LoginToAccount(player, password);
            PlayerAuthHelper.SetLoggedIn(player, true);
        }

        [Command("register", "/register [password]")]
        public void Register(Player player, string password)
        {
            if (IsAlreadyRegistered(player)) return;

            _accountService.RegisterAccount(player, password);
            PlayerAuthHelper.SetLoggedIn(player, true);

            player.SendChatMessage($"~g~Registration successful! Welcome, {player.Name}.");
        }

        private bool ValidateAccount(Player player)
        {
            var account = _accountService.GetAccount(player);

            if (account == null)
            {
                player.SendChatMessage("~r~You are not registered on the server. Please use /register to create an account.");
                return false;
            }

            return true;
        }

        private bool IsAlreadyRegistered(Player player)
        {
            if (_accountService.AccountExists(player))
            {
                player.SendChatMessage("~r~You are already registered on the server. Please use /login to authenticate.");
                return true;
            }

            return false;
        }
    }
}
