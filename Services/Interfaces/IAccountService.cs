namespace CropConnect.Services.Interfaces
{
    public interface IAccountService
    {
        public int Login(string email, string password);
        public int Register(string email, string password);
        public bool ChangePassword(int accountId, string oldPassword, string newPassword);
        public void DeleteAccount(string email, string password);
    }
}
