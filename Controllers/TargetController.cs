using BodyBuildingApp.Controllers.DTO;
using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils.Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Controllers
{
    [Route("/api/target")]
    [ApiController]
    public class TargetController : Controller
    {
        private readonly ITargetService TargetService;
        public TargetController(ITargetService targetService)
        {
            this.TargetService = targetService;
        }
        [HttpGet("{id}")]
        public Target GetTargetbyId(string id)
        {
            if (TargetService.GetTargetbyID(id) == null)
            {
                throw new Exception(" Id not found or not exist");
            }
            else
            {
                return TargetService.GetTargetbyID(id);
            }
        }
        [HttpGet("info")]
        public ActionResult<Target> GetBodyStatusCurrentUser()
        {
            Target target = (Target)this.ViewData["user"];

            var curentCustomer = TargetService.GetTargetbyUserId(target.UserId);
            if (curentCustomer == null)
            {
                return NotFound();
            }
            return curentCustomer;

        }

        [HttpGet("list")]
        public List<Target> GetListTarget()
        {
            if (TargetService.GetAllTarget() == null)
            {
                throw new Exception("Fail to get list");
            }
            else
            {
                return TargetService.GetAllTarget();
            }
        }

        [HttpPut]
        public IActionResult HandleUpdateTarget([FromBody] UpdateTargetDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new UpdateTargetDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var Target = this.TargetService.GetTargetbyID(body.TargetId);

            if (Target == null)
            {
                res.setErrorMessage("Cannot find this Target");
                return new NotFoundObjectResult(res.getResponse());
            }

            Target.TargetName = body.TargetName;

            this.TargetService.UpdateTarget(Target);

            res.setMessage("Update Target success");
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        public IActionResult HandleAddTarget([FromBody] CreateTargetDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new CreateTargetDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var Target = new Target();

            Target.TargetId = Guid.NewGuid().ToString();
            Target.TargetName = body.TargetName;

            this.TargetService.CreateTarget(Target);
            res.setMessage("Add target success!");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete]
        public IActionResult HandleDeleteTarget(string id)
        {
            var res = new ServerApiResponse<string>();

            var Target = this.TargetService.GetTargetbyID(id);

            if (Target == null)
            {
                res.setErrorMessage("Cannot find Target");
                return new NotFoundObjectResult(res.getResponse());
            }

            this.TargetService.DeleteTarget(Target);

            res.setMessage("Delete Target success");
            return new ObjectResult(res.getResponse());
        }
    }
}
