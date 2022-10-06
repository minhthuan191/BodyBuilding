using BodyBuildingApp.Models;
using BodyBuildingApp.Repository.Interface;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Collections.Generic;

namespace BodyBuildingApp.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly DBContext DBContext;
        private readonly ICustomerRepository CustomerRepository;

        public CustomerService(DBContext dBContext, ICustomerRepository CustomerRepository)
        {
            this.DBContext = dBContext;
            this.CustomerRepository = CustomerRepository;
        }
        public List<Customer> GetAllCustomerByRole(string role)
        {
            return this.CustomerRepository.GetListCustomerByRole(role);
        }

        public List<Customer> GetAllCustomers()
        {
            return this.CustomerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(string id)
        {
            return this.CustomerRepository.GetCustomerById(id);
        }

        public Customer GetCustomerByCustomername(string Customername)
        {
            return this.CustomerRepository.GetCustomerByCustomername(Customername);
        }

        public bool ManageAccountHandler(Customer Customer)
        {
            return this.CustomerRepository.ManageAccountHandler(Customer);
        }

        public bool RegisterHandler(Customer Customer)
        {
            return this.CustomerRepository.RegisterHandler(Customer);
        }

        public bool UpdatePasswordHandler(Customer Customer)
        {
            return this.CustomerRepository.UpdatePasswordHandler(Customer);
        }

        public bool UpdateCustomerInfoHandler(Customer Customer)
        {
            return this.CustomerRepository.UpdateCustomerInfoHandler(Customer);
        }
    }
}
