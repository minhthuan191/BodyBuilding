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
    [Route("/api/foodDetail")]
    [ApiController]
    public class FoodDetailController : Controller
    {
        private readonly IFoodDetailService foodDetailService;

        public FoodDetailController(IFoodDetailService foodDetailService)
        {
            this.foodDetailService = foodDetailService;
        }
        [HttpGet("{name}")]
        public IActionResult GetFoodbyName(string name)
        {
            if (foodDetailService.GetFoodbyName(name) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foodDetailService.GetFoodbyName(name));
            }
        }

        [HttpPut("{name}")]
        public IActionResult HandleUpdateFoodDetail([FromBody] UpdateFoodDetailDTO body, string name)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new UpdateFoodDetailDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var fooddetail = this.foodDetailService.GetFoodbyName(name);

            if (fooddetail == null)
            {
                res.setErrorMessage("Cannot find food detail of this user");
                return new NotFoundObjectResult(res.getResponse());
            }

            fooddetail.Calories = body.calories;
            this.foodDetailService.UpdateFoodDetail(fooddetail);

            res.setMessage("Update food detail success");
            return new ObjectResult(res.getResponse());
        }
        [HttpPost]
        public IActionResult HandleAddFoodDetail([FromBody] AddFoodDetailDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddFoodDetailDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };
            Customer customer = (Customer)ViewData["user"];
            var fooddetail = new FoodDetail();

            fooddetail.FoodName = body.FoodName;
            fooddetail.Calories = body.calories;
            fooddetail.Image = body.image;

            this.foodDetailService.CreateFoodDetail(fooddetail);
            res.setMessage("Add food detail success!");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete("{name}")]
        public IActionResult HandleDeleteFoodDetail(string name)
        {
            var res = new ServerApiResponse<string>();


            if (foodDetailService.DeleteFoodDetail(name) == false)
            {
                res.setErrorMessage("Cannot find food detail");
                return new NotFoundObjectResult(res.getResponse());
            }
            else
            {
                this.foodDetailService.DeleteFoodDetail(name);
                res.setMessage("Delete food detail success");
                return new ObjectResult(res.getResponse());
            }

        }
    }
}
