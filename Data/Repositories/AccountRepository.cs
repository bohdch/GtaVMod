using System.Linq;
using GtaVMod.Data.Entities;
using GtaVMod.Data.Interfaces;

namespace GtaVMod.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ModDbContext _modDbContext;

        public AccountRepository(ModDbContext modDbContext)
        {
            _modDbContext = modDbContext;
        }

        public Account GetAccount(string name)
        {
            return _modDbContext.Accounts.FirstOrDefault(a => a.Name == name);
        }

        public void CreateAccount(Account account)
        {
            _modDbContext.Accounts.Add(account);
            _modDbContext.SaveChanges();
        }

        public void UpdateAccount(Account account)
        {
            _modDbContext.Accounts.Update(account);
            _modDbContext.SaveChanges();
        }
    }
}
