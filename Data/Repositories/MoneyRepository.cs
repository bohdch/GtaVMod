using System.Linq;
using GtaVMod.Data.Interfaces;

namespace GtaVMod.Data.Repositories
{
    public class MoneyRepository : IMoneyRepository
    {
        private readonly ModDbContext _modDbContext;

        public MoneyRepository(ModDbContext modDbContext)
        {
            _modDbContext = modDbContext;
        }

        public long GetPlayerMoney(string playerName)
        {
            var account = _modDbContext.Accounts
                .FirstOrDefault(a => a.Name == playerName);

            return account.Cash;
        }

        public void AddPlayerMoney(string playerName, long amount)
        {
            var account = _modDbContext.Accounts
                .FirstOrDefault(a => a.Name == playerName);

            account.Cash += amount;

            _modDbContext.SaveChanges();
        }
    }
}
