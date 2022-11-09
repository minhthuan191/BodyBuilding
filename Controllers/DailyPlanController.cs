using BodyBuildingApp.Auth;
using BodyBuildingApp.Controllers.DTO;
using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils.Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BodyBuildingApp.Controllers
{
    [Route("/api/dailyPlan")]
    [ServiceFilter(typeof(AuthGuard))]
    [ApiController]
    public class DailyPlanController : Controller
    {
        private readonly IDailyPlanService dailyPlanService;

        public DailyPlanController(IDailyPlanService dailyPlanService)
        {
            this.dailyPlanService = dailyPlanService;
        }
        [HttpGet]
        public IActionResult GetAllDailyPlan()
        {
            if (dailyPlanService.GetDailyPlanList() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dailyPlanService.GetDailyPlanList());
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetDailybyPlanID(string id)
        {
            if (dailyPlanService.GetDailybyPlanID(id) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dailyPlanService.GetDailybyPlanID(id));
            }
        }

        [HttpPut("{id}")]
        public IActionResult HandleUpdateDailyPlan([FromBody] UpdateDailyPlanDTO body, string id)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new UpdateDailyPlanDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var dailyPlan = this.dailyPlanService.GetDailybyPlanID(id);

            if (dailyPlan == null)
            {
                res.setErrorMessage("Cannot find daily plan of this user");
                return new NotFoundObjectResult(res.getResponse());
            }

            dailyPlan.Done = body.Done;
            this.dailyPlanService.UpdateDailyPlan(dailyPlan);

            res.setMessage("Update daily plan success");
            return new ObjectResult(res.getResponse());
        }
        [HttpPost]
        public IActionResult HandleAddDailyPlan([FromBody] AddDailyPlan body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddDailyPlanValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };
            Customer customer = (Customer)ViewData["user"];
            var dailyPlan = new DailyPlan();

            dailyPlan.PlanId = Guid.NewGuid().ToString();
            dailyPlan.Date = DateTime.Now.ToShortDateString();
            dailyPlan.DailyFoodDetailId = body.DailyFoodDetailId;
            dailyPlan.InstructionId = body.InstructionId;
            dailyPlan.UserId = customer.UserId;
            dailyPlan.Done = null;

            this.dailyPlanService.CreateDailyPlan(dailyPlan);
            res.setMessage("Add daily plan success!");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete("{id}")]
        public IActionResult HandleDeleteDailyPlan(string id)
        {
            var res = new ServerApiResponse<string>();


            if (dailyPlanService.DeleteDailyPlan(id) == false)
            {
                res.setErrorMessage("Cannot find daily plan");
                return new NotFoundObjectResult(res.getResponse());
            }
            else
            {
                this.dailyPlanService.DeleteDailyPlan(id);
                res.setMessage("Delete daily plan success");
                return new ObjectResult(res.getResponse());
            }

        }
    }
}
