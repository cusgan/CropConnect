using CropConnect.Models;

namespace CropConnect.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public Account? GetAccountByEmail(string email);
        public Account? GetAccountById(int id);
        public void Register(Account account);
    }
}
