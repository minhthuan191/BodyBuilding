using BodyBuildingApp.Repository.Interface;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Auth
{
    public class CustomerFilter : IActionFilter
    {
        private readonly IJwtService JWTService;
        private readonly ICustomerRepository CustomerRepository;
        private readonly ICustomerService CustomerService;
        public CustomerFilter(IJwtService jwtService, ICustomerRepository CustomerRepository, ICustomerService CustomerService)
        {

            this.JWTService = jwtService;
            this.CustomerRepository = CustomerRepository;
            this.CustomerService = CustomerService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            bool isValid = this.GuardHandler(context);
        }

        public bool GuardHandler(ActionExecutingContext context)
        {

            try
            {
                var cookies = new Dictionary<string, string>();
                var values = ((string)context.HttpContext.Request.Headers["Cookie"]).Split(',', ';');


                foreach (var parts in values)
                {
                    var cookieArray = parts.Trim().Split('=');
                    if (cookieArray.Length >= 2)
                    {
                        cookies.Add(cookieArray[0], cookieArray[1]);
                    }
                }

                if (!cookies.TryGetValue("auth-token", out _))
                {
                    return false;
                }
                var token = this.JWTService.VerifyToken(cookies["auth-token"]).Split(";");

                if (token[0] == null)
                {
                    return false;
                }
                var Customer = this.CustomerRepository.GetCustomerById(token[0]);
                if (Customer == null)
                {
                    return false;
                }

                Controller controller = context.Controller as Controller;
                controller.ViewData["Customer"] = Customer;
                return true;

            }
            catch (Exception error)
            {
                return false;
            }
        }
    }
}
