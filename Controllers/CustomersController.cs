using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils.Common;
using FluentValidation.Results;
using BodyBuildingApp.Controllers.DTO;
using BodyBuildingApp.Auth;
using BodyBuildingApp.Service;

namespace BodyBuildingApp.Controllers
{
    [Route("/api/customer")]
    [ServiceFilter(typeof(AuthGuard))]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IAuthService AuthService;
        private readonly ICustomerService CustomerService;

        public CustomersController(ICustomerService customerService, IAuthService authService)
        {
            this.CustomerService = customerService;
            this.AuthService = authService;
        }
   
        [HttpGet("/list")]
        public IActionResult GetListCustomer()
        {
            if (CustomerService.GetAllCustomers() == null)
            {
                return NotFound();
            }
            else
            {
                return Json(CustomerService.GetAllCustomers());
               
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(string id)
        {
            var customer = CustomerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return customer;
            }
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

            this.CustomerService.UpdateCustomerInfoHandler(Customer);

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



            this.CustomerService.UpdatePasswordHandler(Customer);
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
