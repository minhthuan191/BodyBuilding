using BodyBuildingApp.Controllers.DTO;
using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils.Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BodyBuildingApp.Controllers
{
    [Route("/api/dailyfood")]
    [ApiController]
    public class DailyFoodController : Controller
    {
        private readonly IDailyFoodService dailyFoodService;

        public DailyFoodController (IDailyFoodService dailyFoodService)
        {
            this.dailyFoodService = dailyFoodService;
        }

        /*[HttpPut]
        public IActionResult HandleUpdateDailyFood([FromBody] AddDailyFoodDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddDailyFoodDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            Customer customer = (Customer)ViewData["user"];
            var DailyFood = this.DailyFoodService.GetDailyFoodByUserId(customer.UserId);

            if (DailyFood == null)
            {
                res.setErrorMessage("Cannot find body status of this user");
                return new NotFoundObjectResult(res.getResponse());
            }

            DailyFood.Weight = body.Weight;
            DailyFood.Height = body.Height;
            DailyFood.Date = DateTime.Now.ToShortDateString();

            this.dailyFoodService.Updatebody(DailyFood);

            res.setMessage("Update body status success");
            return new ObjectResult(res.getResponse());
        }
        [HttpPost]
        public IActionResult HandleAddDailyFood([FromBody] AddDailyFoodDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddDailyFoodDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var DailyFood = new DailyFood();
            
            DailyFood.DailyFoodId = Guid.NewGuid().ToString();
            DailyFood.FoodName = body.FoodName;
            DailyFood.TimetoEat = body.TimeToEat;
            DailyFood.Recommend = body.Recommend;

            this.dailyFoodService.CreateDailyFood(DailyFood);
            res.setMessage("Add body status success!");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete]
        public IActionResult HandleDeleteDailyFood()
        {
            var res = new ServerApiResponse<string>();

            Customer customer = (Customer)ViewData["user"];
            var DailyFood = this.dailyFoodService.GetDailyFoodbyID(customer.UserId);

            if (DailyFood == null)
            {
                res.setErrorMessage("Cannot find dailyfood of this user");
                return new NotFoundObjectResult(res.getResponse());
            }

            this.dailyFoodService.DeleteDailyFood(DailyFood);

            res.setMessage("Delete DailyFood success");
            return new ObjectResult(res.getResponse());
        }
       */
    }
}
