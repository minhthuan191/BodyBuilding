using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using BodyBuildingApp.Utils.Interface;

namespace BodyBuildingApp.Service
{
    public class AuthService : IAuthService
    {
        private readonly DBContext DBContext;
        private readonly ICustomerRepository CustomerRepository;
        private readonly IJwtService JWTService;
        public AuthService(DBContext dBContext, ICustomerRepository customerRepository, IJwtService jwtService)
        {
            this.DBContext = dBContext;
            this.CustomerRepository = customerRepository;
            this.JWTService = jwtService;
        }

        public bool RegisterHandler(Customer customer)
        {
            return this.CustomerRepository.RegisterHandler(customer);
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
