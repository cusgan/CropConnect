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

        public bool Register(string email, string password)
        {
            var acc = _accountRepository.GetAccountByEmail(email);
            if (acc != null) return false;

            acc = new Models.Account()
            {
                Email = email,
                PasswordHash = HashPassword(password)
            };
            _accountRepository.Register(acc);
            return true;
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
