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
    [ServiceFilter(typeof(AuthGuard))]
    [Route("/api/dailyfood")]
    [ApiController]
    public class DailyFoodController : Controller
    {
        //private readonly IDailyFoodService dailyFoodService;

        //public DailyFoodController(IDailyFoodService dailyFoodService)
        //{
        //    this.dailyFoodService = dailyFoodService;
        //}

        ////        [HttpGet]
        ////        public IActionResult GetAllDailyFood()
        ////        {
        ////            if (dailyFoodService.GetDailyFoodList == null)
        ////            {
        ////                return NotFound();
        ////            }
        ////            else
        ////            {
        ////                return Ok(dailyFoodService.GetDailyFoodList());
        ////            }
        ////        }

        ////        [HttpGet("{id}")]
        ////        public IActionResult GetDailyFoodbyID(string id)
        ////        {
        ////            if (dailyFoodService.GetDailyFoodbyID(id) == null)
        ////            {
        ////                return NotFound();
        ////            }
        ////            else
        ////            {
        ////                return Ok(dailyFoodService.GetDailyFoodbyID(id));
        ////            }
        ////        }

        ////        [HttpPut("{id}")]
        ////        public IActionResult HandleUpdateDailyFood([FromBody] AddDailyFoodDTO body, string id)
        ////        {
        ////            var res = new ServerApiResponse<string>();

        ////            ValidationResult result = new AddDailyFoodDTOValidator().Validate(body);
        ////            if (!result.IsValid)
        ////            {
        ////                res.mapDetails(result);
        ////                return new BadRequestObjectResult(res.getResponse());
        ////            };

        ////            var DailyFood = this.dailyFoodService.GetDailyFoodbyID(id);

        ////            if (DailyFood == null)
        ////            {
        ////                res.setErrorMessage("Cannot find Daily Food ");
        ////                return new NotFoundObjectResult(res.getResponse());
        ////            }

        ////            DailyFood.TimetoEat = body.TimeToEat;
        ////            DailyFood.Recommend = body.Recommend;

        ////            this.dailyFoodService.UpdateDailyFood(DailyFood);

        ////            res.setMessage("Update Daily Food success");
        ////            return new ObjectResult(res.getResponse());
        ////        }
        ////        [HttpPost]
        ////        public IActionResult HandleAddDailyFood([FromBody] AddDailyFoodDTO body)
        ////        {
        ////            var res = new ServerApiResponse<string>();

        ////            ValidationResult result = new AddDailyFoodDTOValidator().Validate(body);
        ////            if (!result.IsValid)
        ////            {
        ////                res.mapDetails(result);
        ////                return new BadRequestObjectResult(res.getResponse());
        ////            };

        ////            var DailyFood = new DailyFood();

        ////            DailyFood.DailyFoodId = Guid.NewGuid().ToString();
        ////            DailyFood.TimetoEat = body.TimeToEat;
        ////            DailyFood.Recommend = body.Recommend;

        ////            this.dailyFoodService.CreateDailyFood(DailyFood);
        ////            res.setMessage("Add Daily Food success!");
        ////            return new ObjectResult(res.getResponse());
        ////        }

        ////        [HttpDelete("{id}")]
        ////        public IActionResult HandleDeleteDailyFood(string id)
        ////        {
        ////            var res = new ServerApiResponse<string>();


        ////            if (dailyFoodService.DeleteDailyFood(id) == false)
        ////            {
        ////                res.setErrorMessage("Cannot find dailyfood");
        ////                return new NotFoundObjectResult(res.getResponse());
        ////            }
        ////            else
        ////            {
        ////                this.dailyFoodService.DeleteDailyFood(id);
        ////                res.setMessage("Delete DailyFood success");
        ////                return new ObjectResult(res.getResponse());
        ////            }

        ////        }
    }
}
