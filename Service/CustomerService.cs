using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository CustomerRepository;
        public CustomerService(CustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
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
            if(id == null){
                throw new Exception("error at get customer by id");
            }else
            {
                return CustomerRepository.GetCustomerById(id);
            }
        }

        public Customer GetCustomerByEmail(string email)
        {
            return this.CustomerRepository.GetCustomerByEmail(email);
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
