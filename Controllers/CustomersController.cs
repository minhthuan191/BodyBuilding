﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BodyBuildingApp.Models;
using BodyBuildingApp.Utils;
using BodyBuildingApp.Repository.Interface;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils.Common;
using FluentValidation.Results;
using BodyBuildingApp.Controllers.DTO;
using BodyBuildingApp.Service;

namespace BodyBuildingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository CustomerRepository;
        private readonly IAuthService AuthService;
        private readonly ICustomerService CustomerService;

        public CustomersController(ICustomerRepository customerRepository,  ICustomerService customerService, IAuthService authService)
        {
            this.CustomerRepository = customerRepository;
            this.CustomerService = customerService;
            this.AuthService = authService;
        }

        [HttpPost("updateinfo")]
        public IActionResult HandleUpdateCustomerInfo([FromBody] UpdateCustomerDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new UpdateCustomerDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            Customer Customer = (Customer)this.ViewData["Customer"];

            Customer.Name = body.Name;
            Customer.Phone = body.Phone;
            Customer.Address = body.Address;
            Customer.Email = body.Email;

            this.CustomerRepository.UpdateCustomerInfoHandler(Customer);

            res.setMessage("Update Customer infomation success!");
            return new ObjectResult(res.getResponse());
        }
        [HttpPost("password")]
        public IActionResult HandleUpdatePassword([FromBody] ChangePasswordDTO body)
        {
            var res = new ServerApiResponse<string>();
            ValidationResult result = new ChangePasswordDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            Customer Customer = (Customer)this.ViewData["Customer"];
            bool checkPassword = AuthService.ComparePassword(body.Password, Customer.Password);
            if (!checkPassword)
            {
                res.setErrorMessage("Old Password is not correct!");
                return new BadRequestObjectResult(res.getResponse());
            }
            if (!(body.NewPassword == body.ConfirmNewPassword))
            {
                res.setErrorMessage("Confirm password does not match new password");
                return new BadRequestObjectResult(res.getResponse());
            }
            Customer.Password = body.NewPassword;



            this.CustomerRepository.UpdatePasswordHandler(Customer);
            this.HttpContext.Response.Cookies.Append("auth-token", "", new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1),
                SameSite = SameSiteMode.None,
                Secure = true

            });
            res.setMessage("Change Password success!");
            return new ObjectResult(res.getResponse());
        }
    }
}
