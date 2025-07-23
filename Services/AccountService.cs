using GTANetworkAPI;
using GtaVMod.Constants;
using GtaVMod.Data.Entities;
using GtaVMod.Data.Interfaces;
using GtaVMod.Exceptions;
using GtaVMod.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GtaVMod.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly PasswordHasher<Account> _passwordHasher;
        
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _passwordHasher = new PasswordHasher<Account>();
        }

        public Account GetAccount(Player player)
        {
            Account result = null;

            HandleException.Execute(() =>
            {
                result = _accountRepository.GetAccount(player.Name);
            });

            return result;
        }

        public void LoginToAccount(Player player, string password)
        {
            HandleException.Execute(() =>
            {
                var account = _accountRepository.GetAccount(player.Name);
                if (account == null)
                {
                    player.SendChatMessage("~r~Account not found.");
                    return;
                }

                var result = _passwordHasher.VerifyHashedPassword(account, account.Password, password);
                if (result != PasswordVerificationResult.Success)
                {
                    player.SendChatMessage("~r~Invalid password. Please try again.");
                    return;
                }

                player.SendChatMessage($"~g~Login successful! Welcome back, {player.Name}.");
                player.Position = new Vector3(account.X, account.Y, account.Z);
            });
        }

        public void RegisterAccount(Player player, string password)
        {
            HandleException.Execute(() =>
            {
                var account = _accountRepository.GetAccount(player.Name);

                if (account == null)
                {
                    account = new Account
                    {
                        Name = player.Name,
                        Cash = PlayerConstants.DefaultMoney,
                        X = player.Position.X,
                        Y = player.Position.Y,
                        Z = player.Position.Z
                    };

                    account.Password = _passwordHasher.HashPassword(account, password);

                    _accountRepository.CreateAccount(account);
                }
            });
        }

        public bool AccountExists(Player player)
        {
            bool exists = false;

            HandleException.Execute(() =>
            {
                var account = _accountRepository.GetAccount(player.Name);
                exists = account != null;
            });

            return exists;
        }

        public void UpdatePlayerPosition(string playerName, float x, float y, float z)
        {
            HandleException.Execute(() =>
            {
                var account = _accountRepository.GetAccount(playerName);
                if (account != null)
                {
                    account.X = x;
                    account.Y = y;
                    account.Z = z;

                    _accountRepository.UpdateAccount(account);
                }
            });
        }
    }
}
