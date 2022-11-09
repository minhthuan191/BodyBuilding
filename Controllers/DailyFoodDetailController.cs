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
    [Route("/api/dailyfood")]
    [ApiController]
    public class DailyFoodDetailController : Controller
    {
        private readonly IDailyFoodDetailService dailyFoodDetailService;

        public DailyFoodDetailController(IDailyFoodDetailService dailyFoodDetailService)
        {
            this.dailyFoodDetailService = dailyFoodDetailService;
        }

        [HttpGet("list")]
        public IActionResult GetAllDailyFood()
        {
            if (dailyFoodDetailService.GetAllDailyFoodDetail() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dailyFoodDetailService.GetAllDailyFoodDetail());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDailyFoodbyID(string id)
        {
            if (dailyFoodDetailService.GetDailyFoodDetailId(id) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dailyFoodDetailService.GetDailyFoodDetailId(id));
            }
        }

        [HttpPut("{id}")]
        public IActionResult HandleUpdateDailyFood([FromBody] AddDailyFoodDetailDTO body, string id)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddDailyFoodDetailDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var dailyFood = this.dailyFoodDetailService.GetDailyFoodDetailId(id);

            if (dailyFood == null)
            {
                res.setErrorMessage("Cannot find Daily Food ");
                return new NotFoundObjectResult(res.getResponse());
            }

            dailyFood.FoodName = body.foodName;
            dailyFood.TimetoEat = body.TimeToEat;
            dailyFood.Recommend = body.Recommend;

            this.dailyFoodDetailService.UpdateDailyFoodDetail(dailyFood);

            res.setMessage("Update Daily Food success");
            return new ObjectResult(res.getResponse());
        }
        [HttpPost]
        public IActionResult HandleAddDailyFood([FromBody] AddDailyFoodDetailDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddDailyFoodDetailDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var DailyFood = new DailyFoodDetail();
            DailyFood.DailyFoodDetailId = Guid.NewGuid().ToString();
            DailyFood.FoodName = body.foodName;
            DailyFood.TimetoEat = body.TimeToEat;
            DailyFood.Recommend = Recommend.RECOMMEND;

            this.dailyFoodDetailService.CreateDailyFoodDetail(DailyFood);
            res.setMessage("Add Daily Food success!");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete("{id}")]
        public IActionResult HandleDeleteDailyFood(string id)
        {
            var res = new ServerApiResponse<string>();


            if (dailyFoodDetailService.DeteleDailyFoodDetail(id) == false)
            {
                res.setErrorMessage("Cannot find dailyfood");
                return new NotFoundObjectResult(res.getResponse());
            }
            else
            {
                this.dailyFoodDetailService.DeteleDailyFoodDetail(id);
                res.setMessage("Delete DailyFood success");
                return new ObjectResult(res.getResponse());
            }

        }
    }
}
