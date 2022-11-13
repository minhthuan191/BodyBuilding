﻿
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils.Common;
using BodyBuildingApp.Utils.Interface;
using BodyBuildingApp.Utils.Locale;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Auth
{
    public class AuthGuard : IActionFilter
    {
        private readonly IJwtService JWTService;
        private readonly ICustomerService CustomerService;
        private readonly ITrainerService TrainerService;
        public AuthGuard(IJwtService jwtService, ICustomerService CustomerService, ITrainerService trainerService)
        {

            this.JWTService = jwtService;
            this.CustomerService = CustomerService;
            this.TrainerService = trainerService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {


        }

        public bool GuardHandler(ActionExecutingContext context)
        {

            try
            {
                var cookies = new Dictionary<string, string>();
                var accessToken = ((string)context.HttpContext.Request.Headers["auth-token"]);
                if (accessToken == null)
                {
                    return false;
                }

                var token = this.JWTService.VerifyToken(accessToken).Split(";");

                if (token[0] == null)
                {
                    return false;
                }
                var user = this.CustomerService.GetCustomerById(token[0]);
                
                if (user == null)
                {
                    var trainer = this.TrainerService.GetTrainerById(token[0]);

                    if (trainer == null)
                    {
                        return false;
                    }

                    Controller controller1 = context.Controller as Controller;
                    controller1.ViewData["trainer"] = user;

                    // check user's role

                }

                Controller controller = context.Controller as Controller;
                controller.ViewData["user"] = user;

                // check user's role
                if (context.ActionArguments.TryGetValue("roles", out _))
                {
                    string roles = context.ActionArguments["roles"] as String;
                    if (!roles.Contains(user.Role))
                    {
                        return false;
                    }
                }
                //

                return true;

            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return false;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            bool isValid = this.GuardHandler(context);
            if (!isValid)
            {
                Controller controller = context.Controller as Controller;
                ServerResponse.SetErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_ALLOW_ACTION, controller.ViewData);
                context.Result = new ViewResult
                {
                    //ViewName = Routers.Login.Page,
                };
                return;
            }
        }
    }
}
