namespace GtaVMod.Data.Interfaces
{
    public interface IMoneyRepository
    {
        long GetPlayerMoney(string playerName);

        void AddPlayerMoney(string playerName, long amount);
    }
}
