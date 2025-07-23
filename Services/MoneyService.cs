using GTANetworkAPI;
using GtaVMod.Data.Interfaces;
using GtaVMod.Exceptions;
using GtaVMod.Interfaces;

namespace GtaVMod.Services
{
    public class MoneyService : IMoneyService
    {
        private IMoneyRepository _moneyRepository;

        public MoneyService(IMoneyRepository moneyRepository)
        {
            _moneyRepository = moneyRepository;
        }

        public long GetMoney(Player player)
        {
            long money = 0;

            HandleException.Execute(() =>
            {
                money = _moneyRepository.GetPlayerMoney(player.Name);
            });

            return money;
        }

        public void AddMoney(Player player, long amount)
        {
            HandleException.Execute(() =>
            {
                _moneyRepository.AddPlayerMoney(player.Name, amount);
            });
        }
    }
}
