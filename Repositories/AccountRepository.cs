using CropConnect.Models;
using CropConnect.Repositories.Interfaces;
using System;

namespace CropConnect.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _appDbContext;
        public AccountRepository(AppDbContext appDbContext) { _appDbContext = appDbContext; }

        
        public Account? GetAccountByEmail(string email)
        {
            return _appDbContext.Account.SingleOrDefault(x => Equals(x.Email,email));
        }
        public Account? GetAccountById(int id)
        {
            return _appDbContext.Account.SingleOrDefault(x => x.Id == id);
        }
        public void Register(Account acc)
        {
            _appDbContext.Account.Add(acc);
            _appDbContext.SaveChanges();
        }
        public bool ChangePassword(int accountId, string newPasswordHash)
        {
            var acc = _appDbContext.Account.SingleOrDefault(x => x.Id == accountId);
            if (acc == null) return false;

            acc.PasswordHash = newPasswordHash;
            _appDbContext.SaveChanges();
            return true;
        }
        public void DeleteAccountById(int id)
        {
            Account? acc = _appDbContext.Account.SingleOrDefault(x => x.Id == id);
            if (acc != null)
            {
                _appDbContext.Account.Remove(acc);
                _appDbContext.SaveChanges();
            }
        }
    }
}
