using BodyBuildingApp.Models;

namespace BodyBuildingApp.Service.Interface
{
    public interface IAuthService
    {
        public string LoginHandler(string customerId);
        public bool RegisterHandler(Customer customer);
        public string HashingPassword(string password);
        public bool ComparePassword(string inputPassword, string encryptedPassword);
    }
}
