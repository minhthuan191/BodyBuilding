using BodyBuildingApp.Auth;
using BodyBuildingApp.Controllers.DTO;
using BodyBuildingApp.Models;
using BodyBuildingApp.Service;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils.Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;


namespace BodyBuildingApp.Controllers
{
    [ServiceFilter(typeof(AuthGuard))]
    [Route("/api/bodystatus")]
    [ApiController]
    public class BodyStatusController : Controller
    {
        private readonly IBodyStatusService bodyStatusService;

        public BodyStatusController(IBodyStatusService bodyStatusService)
        {
            this.bodyStatusService = bodyStatusService;
        }

        [HttpGet("info")]
        public ActionResult<BodyStatus> GetCurrentCustomer()
        {
            Customer Customer = (Customer)this.ViewData["user"];


            var bodyStatus = bodyStatusService.GetBodyStatusByUserId(Customer.UserId);
            if (bodyStatus == null)
            {
                return NotFound();
            }
            return bodyStatus;

        }

        [HttpGet]
        public IActionResult GetBodyStatusbyId(string id)
        {
            var res = new ServerApiResponse<string>();

            BodyStatus bodyStatus = bodyStatusService.GetBodyStatusByBodyID(id);
            if (bodyStatus == null)
            {
                res.setErrorMessage("Can not find this body ID");
                return new NotFoundObjectResult(res.getResponse());
            }
            return new ObjectResult(bodyStatus);

        }
        [HttpPut]
        public IActionResult HandleUpdateBodyStatus([FromBody]AddBodyStatusDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddBodyStatusDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            Customer customer = (Customer)ViewData["user"];
            var bodyStatus = this.bodyStatusService.GetBodyStatusByUserId(customer.UserId);

            if (bodyStatus == null)
            {
                res.setErrorMessage("Cannot find body status of this user");
                return new NotFoundObjectResult(res.getResponse());
            }

            bodyStatus.Weight = body.Weight;
            bodyStatus.Height = body.Height;
            bodyStatus.Date = DateTime.Now.ToShortDateString();

            this.bodyStatusService.Updatebody(bodyStatus);

            res.setMessage("Update body status success");
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        public IActionResult HandleAddBodyStatus([FromBody]AddBodyStatusDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddBodyStatusDTOValidator().Validate(body);
            if ( !result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var bodyStatus = new BodyStatus();
            Customer customer = (Customer)ViewData["user"];

            bodyStatus.BodyStatusId = Guid.NewGuid().ToString();
            bodyStatus.Weight = body.Weight;
            bodyStatus .Height = body.Height;
            bodyStatus.UserId = customer.UserId;
            bodyStatus.Date = DateTime.Now.ToShortDateString();

            this.bodyStatusService.Createbody(bodyStatus);
            res.setMessage("Add body status success!");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete]
        public IActionResult HandleDeleteBodyStatus()
        {
            var res = new ServerApiResponse<string>();

            Customer customer = (Customer)ViewData["user"];
            var bodyStatus = this.bodyStatusService.GetBodyStatusByUserId(customer.UserId);

            if (bodyStatus == null)
            {
                res.setErrorMessage("Cannot find body status of this user");
                return new NotFoundObjectResult(res.getResponse());
            }

            this.bodyStatusService.Deletebody(bodyStatus);

            res.setMessage("Delete bodystatus success");
            return new ObjectResult(res.getResponse());
        }
    }
}
