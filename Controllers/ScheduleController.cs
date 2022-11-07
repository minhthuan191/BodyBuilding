using BodyBuildingApp.Auth;
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
    [ServiceFilter(typeof(AuthGuard))]
    [Route("/api/schedule")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }
        [HttpGet("{name}")]
        public IActionResult GetFoodbyName(string id)
        {
            if (scheduleService.GetScheduleById(id) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(scheduleService.GetScheduleById(id));
            }
        }

        [HttpPut("{name}")]
        public IActionResult HandleUpdateFoodDetail([FromBody] UpdateScheduleDTO body, string id)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new UpdateScheduleDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var schedule = this.scheduleService.GetScheduleById(id);

            if (schedule == null)
            {
                res.setErrorMessage("Cannot find food detail of this user");
                return new NotFoundObjectResult(res.getResponse());
            }

            schedule.Status = body.Status;
            this.scheduleService.UpdateSchedule(schedule);

            res.setMessage("Update food detail success");
            return new ObjectResult(res.getResponse());
        }
        [HttpPost]
        public IActionResult HandleAddFoodDetail([FromBody] AddScheduleDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddScheduleDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };
            Customer customer = (Customer)ViewData["user"];
            var schedule = new Schedule();
            schedule.ScheduleId = body.scheduleId;
            schedule.StartDate = body.StartDate;
            schedule.EndDate = body.EndDate;
            schedule.Status = body.Status;
            schedule.UserId = customer.Name;

            this.scheduleService.CreateSchedule(schedule);
            res.setMessage("Add food detail success!");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete("{name}")]
        public IActionResult HandleDeleteFoodDetail(string id)
        {
            var res = new ServerApiResponse<string>();


            if (scheduleService.DeleteSchedule(id) == false)
            {
                res.setErrorMessage("Cannot find food detail");
                return new NotFoundObjectResult(res.getResponse());
            }
            else
            {
                this.scheduleService.DeleteSchedule(id);
                res.setMessage("Delete food detail success");
                return new ObjectResult(res.getResponse());
            }

        }
    }
}
