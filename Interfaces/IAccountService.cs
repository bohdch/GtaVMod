using GTANetworkAPI;
using GtaVMod.Data.Entities;

namespace GtaVMod.Interfaces
{
    public interface IAccountService
    {
        Account GetAccount(Player player);

        void LoginToAccount(Player player, string password);

        void RegisterAccount(Player player, string password);

        bool AccountExists(Player player);

        void UpdatePlayerPosition(string playerName, float x, float y, float z);
    }
}
