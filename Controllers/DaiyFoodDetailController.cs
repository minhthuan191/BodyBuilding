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
    [Route("/api/DailyFoodDetail")]
    [ApiController]
    public class DaiyFoodDetailController
    {

        private readonly IDailyFoodDetailService dailyFoodDetail;

        public DaiyFoodDetailController(IDailyFoodDetailService dailyFoodDetail)
        {
            this.dailyFoodDetail = dailyFoodDetail;
        }

        
    }
}
