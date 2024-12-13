using CropConnect.Repositories.Interfaces;
using CropConnect.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace CropConnect.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) { _accountRepository = accountRepository; }
        public bool Login(string email, string password)
        {
            var acc = _accountRepository.GetAccountByEmail(email);
            if (acc == null) return false;

            string storedHash = acc.PasswordHash;
            return (Equals(HashPassword(password), storedHash));
        }

        public int Register(string email, string password)
        {
            var acc = _accountRepository.GetAccountByEmail(email);
            if (acc != null) return -1;

            acc = new Models.Account()
            {
                Email = email,
                PasswordHash = HashPassword(password)
            };
            _accountRepository.Register(acc);
            var created_acc = _accountRepository.GetAccountByEmail(email);
            return created_acc.Id;
        }
        public void DeleteAccount(string email, string password)
        {
            if (Login(email, password))
            {
                int accountId = _accountRepository.GetAccountByEmail(email)!.Id;
                _accountRepository.DeleteAccountById(accountId);
            }
        }
        public bool ChangePassword(int accountId, string oldPassword, string newPassword)
        {
            var acc = _accountRepository.GetAccountById(accountId);
            if (
                acc == null || 
                !Equals(
                    HashPassword(oldPassword),
                    acc.PasswordHash
                    )
                ) 
                return false;
            return _accountRepository.ChangePassword(accountId, HashPassword(newPassword));
        }
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
