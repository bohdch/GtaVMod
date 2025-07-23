using GTANetworkAPI;
using Microsoft.Extensions.DependencyInjection;
using GtaVMod.Interfaces;
using Player = GTANetworkAPI.Player;

namespace GtaVMod.Commands
{
    public class MoneyCommands : Script
    {
        private readonly IMoneyService _moneyService;

        public MoneyCommands()
        {
            _moneyService = ServicesContainer.ServiceProvider.GetService<IMoneyService>();
        }

        [Command("money")]
        public void CheckMoney(Player player)
        {
            CommandProxy.ExecuteIfLoggedIn(player, p =>
            {
                var balance = _moneyService.GetMoney(p);
                p.SendChatMessage($"~y~Your balance: ~g~${balance}");
            });
        }

        [Command("give")]
        public void GiveMoney(Player sender, string player, int amount)
        {
            CommandProxy.ExecuteIfLoggedIn(sender, p =>
            {
                var targetPlayer = NAPI.Player.GetPlayerFromName(player);
                if (targetPlayer == null)
                {
                    p.SendChatMessage($"~r~Player '{player}' not found.");
                    return;
                }

                _moneyService.AddMoney(targetPlayer, amount);
                p.SendChatMessage($"~g~{targetPlayer.Name} received ${amount}.");
            });
        }
    }
}
