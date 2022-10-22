using BodyBuildingApp.Repository.Interface;
using BodyBuildingApp.Utils.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Auth
{
    public class RoleGuardAttribute : ActionFilterAttribute
    {
        private readonly string roles;
        public RoleGuardAttribute(string roles)
        {
            this.roles = roles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments["roles"] = this.roles;
        }
    }
}
