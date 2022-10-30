using BodyBuildingApp.Models;
using BodyBuildingApp.Service;
using BodyBuildingApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BodyBuildingApp.Controllers
{
    [Route("/api/bodystatus")]
    [ApiController]
    public class BodyStatusController : Controller
    {
        private readonly IBodyStatusService bodyStatusService;

        public BodyStatusController(IBodyStatusService bodyStatusService)
        {
            this.bodyStatusService = bodyStatusService;
        }
        [HttpGet]
        public BodyStatus GetBodyStatusbyId(string id)
        {
            if (bodyStatusService.GetBodyStatusByBodyID(id) == null)
            {
                throw new Exception(" Id not found or not exist");
            }
            else
            {
                return bodyStatusService.GetBodyStatusByBodyID(id);
            }
        }
        [HttpPut]
        public bool Updatebody(BodyStatus bodyStatus)
        {
                return bodyStatusService.Updatebody(bodyStatus);
        }

        [HttpPost]
        public bool CreateBodyStatus(BodyStatus bodyStatus)
        {
            return bodyStatusService.Createbody(bodyStatus);
        }

        [HttpDelete]
        public bool DeleteBody(string id)
        {
           return bodyStatusService.Deletebody(id);
        }
    }
}
