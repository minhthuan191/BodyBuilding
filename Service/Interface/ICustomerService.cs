using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface ICustomerService
    {
        public bool UpdatePasswordHandler(Customer Customer);
        public bool UpdateCustomerInfoHandler(Customer Customer);
        public Customer GetCustomerById(string id);
        public Customer GetCustomerByEmail(string email);
        public bool RegisterHandler(Customer Customer);
        public List<Customer> GetAllCustomers();
        public List<Customer> GetAllCustomerByRole(Role role);
        public bool ManageAccountHandler(Customer Customer);
    }
}
