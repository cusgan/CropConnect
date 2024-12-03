namespace CropConnect.Services.Interfaces
{
    public interface IAccountService
    {
        public bool Login(string email, string password);
        public bool Register(string email, string password);
    }
}
