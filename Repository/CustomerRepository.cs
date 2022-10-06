﻿using BodyBuildingApp.Models;
using BodyBuildingApp.Utils;
using System.Collections.Generic;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class CustomerRepository
    { 

        private readonly DBContext DBContext;
        public CustomerRepository(DBContext dBContext)
        {
        this.DBContext = dBContext;
        }

        public Customer GetCustomerByEmail(string email)
        {
            Customer Customer = this.DBContext.Customer.FirstOrDefault(item => item.Email == email);
            return Customer;
        }

        public Customer GetCustomerById(string id)
        {
            Customer Customer = this.DBContext.Customer.FirstOrDefault(item => item.UserId == id);
            return Customer;
        }

        public bool RegisterHandler(Customer customer)
        {
            this.DBContext.Customer.Add(customer);
            return this.DBContext.SaveChanges() > 0;
        }
        public bool UpdatePasswordHandler(Customer Customer)
        {
            this.DBContext.Customer.Update(Customer);
            this.DBContext.SaveChanges();
            return true;
        }
        public bool UpdateCustomerInfoHandler(Customer Customer)
        {
            this.DBContext.Customer.Update(Customer);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool ManageAccountHandler(Customer Customer)
        {
            this.DBContext.Customer.Update(Customer);
            return this.DBContext.SaveChanges() > 0;
        }
        public List<Customer> GetAllCustomers()
        {
            List<Customer> listCustomer = this.DBContext.Set<Customer>().ToList<Customer>();
            return listCustomer;
        }

        public List<Customer> GetListCustomerByRole(Role role)
        {
            List<Customer> listCustomer = this.DBContext.Customer.Where(item => item.Role == role).ToList();
            return listCustomer;
        }
    }
}
