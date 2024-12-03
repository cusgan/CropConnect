using CropConnect.Models;
using CropConnect.Repositories.Interfaces;

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
    }
}
