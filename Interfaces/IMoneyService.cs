using GTANetworkAPI;

namespace GtaVMod.Interfaces
{
    public interface IMoneyService
    {
        long GetMoney(Player player);

        void AddMoney(Player player, long amount);
    }
}
