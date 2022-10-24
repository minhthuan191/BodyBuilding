using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerByEmail(string email);
        public Customer GetCustomerById(string id);
        public bool RegisterHandler(Customer Customer);
        public bool UpdatePasswordHandler(Customer Customer);
        public bool UpdateCustomerInfoHandler(Customer Customer);
        public List<Customer> GetAllCustomers();
        public List<Customer> GetListCustomerByRole(string role);
        public bool ManageAccountHandler(Customer Customer);
    }
}
