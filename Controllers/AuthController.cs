using BodyBuildingApp.Controllers.DTO;
using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils.Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BodyBuildingApp.Controllers
{
    [Route("/api/auth")]
    [ApiController]
    public class AuthApiController : Controller
    {
        private readonly IAuthService AuthService;
        private readonly ICustomerService CustomerService;
        private readonly ITrainerService TrainerService;

        public AuthApiController(IAuthService authService, ICustomerService customerService, ITrainerService trainerService)
        {
            this.AuthService = authService;
            this.CustomerService = customerService;
            this.TrainerService = trainerService;
        }

        [HttpPost("login")]
        public IActionResult HandleLogin([FromBody] LoginDTO body)
        {
            var res = new ServerApiResponse<string>();
            ValidationResult result = new LoginDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var user = this.CustomerService.GetCustomerByEmail(body.Email);
            if (user == null)
            {
                res.setErrorMessage("email or password is wrong");
                return new BadRequestObjectResult(res.getResponse());
            }

            if (!this.AuthService.ComparePassword(body.Password, user.Password))
            {
                res.setErrorMessage("email or password is wrong");
                return new BadRequestObjectResult(res.getResponse());
            }

            var token = this.AuthService.LoginHandler(user.UserId);

            if (token == null)
            {
                res.setErrorMessage("email or password is wrong");
                return new BadRequestObjectResult(res.getResponse());
            }

            this.HttpContext.Response.Cookies.Append("auth-token", token, new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(30),
                SameSite = SameSiteMode.None,
                Secure = true

            });
            Console.WriteLine("--------------");
            res.data = token;
            res.setMessage("login success");

            return new ObjectResult(res.getResponse());
        }

        [HttpPost("login/trainer")]
        public IActionResult HandleLoginForTrainer([FromBody] LoginTrainerDTO body)
        {
            var res = new ServerApiResponse<string>();
            ValidationResult result = new LoginTrainerDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var trainer = this.TrainerService.GetTrainerByPhone(body.Phone);
            if (trainer == null)
            {
                res.setErrorMessage("Phone or password is wrong");
                return new BadRequestObjectResult(res.getResponse());
            }

            if (!this.AuthService.ComparePassword(body.Password, trainer.Password))
            {
                res.setErrorMessage("Phone or password is wrong");
                return new BadRequestObjectResult(res.getResponse());
            }

            var token = this.AuthService.LoginHandler(trainer.TrainerId);

            if (token == null)
            {
                res.setErrorMessage("Phone or password is wrong");
                return new BadRequestObjectResult(res.getResponse());
            }

            this.HttpContext.Response.Cookies.Append("auth-token", token, new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(30),
                SameSite = SameSiteMode.None,
                Secure = true

            });
            Console.WriteLine("--------------");
            res.data = token;
            res.setMessage("login success");

            return new ObjectResult(res.getResponse());
        }

        [HttpPost("register")]
        public IActionResult HandleRegister([FromBody] RegisterDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new RegisterDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var isExistUser = this.CustomerService.GetCustomerByEmail(body.Email);
            if (isExistUser != null)
            {
                res.setErrorMessage("is already exist", "Email");
                return new BadRequestObjectResult(res.getResponse());
            }

            var customer = new Customer();
            customer.UserId = Guid.NewGuid().ToString();
            customer.Name = body.Name;
            customer.Gender = body.Gender;
            customer.Phone = body.Phone;
            customer.Address = body.Address;
            customer.Email = body.Email;
            customer.Role = body.Role;
            customer.Password = body.Password;


            this.AuthService.RegisterHandler(customer);

            res.setMessage("register success");
            return new ObjectResult(res.getResponse());
        }
    }
    }
