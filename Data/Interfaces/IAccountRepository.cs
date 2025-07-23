using GtaVMod.Data.Entities;

namespace GtaVMod.Data.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccount(string name);

        void CreateAccount(Account account);

        void UpdateAccount(Account account);
    }
}
