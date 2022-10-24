using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using BodyBuildingApp.Utils.Interface;

namespace BodyBuildingApp.Service
{
    public class AuthService : IAuthService
    {
        private readonly DBContext DBContext;
        private readonly ICustomerService CustomerService;
        private readonly IJwtService JWTService;
        public AuthService(DBContext dBContext, ICustomerService customerService, IJwtService jwtService)
        {
            this.DBContext = dBContext;
            this.CustomerService = customerService;
            this.JWTService = jwtService;
        }

        public bool RegisterHandler(Customer customer)
        {
            return this.CustomerService.RegisterHandler(customer);
        }


        public string LoginHandler(string CustomerId)
        {
            string token = this.JWTService.GenerateToken(CustomerId);
            return token;
        }

        public string HashingPassword(string password)

        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 8);
        }

        public bool ComparePassword(string inputPassword, string encryptedPassword)
        {
            return inputPassword.Equals(encryptedPassword);
        }
    }
}
