using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Repository.Interface
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerByCustomername(string Customername);
        public Customer GetCustomerById(string id);
        public bool RegisterHandler(Customer Customer);
        public bool UpdatePasswordHandler(Customer Customer);
        public bool UpdateCustomerInfoHandler(Customer Customer);
        public List<Customer> GetAllCustomers();
        public List<Customer> GetListCustomerByRole(string roleId);
        public bool ManageAccountHandler(Customer Customer);
    }
}
