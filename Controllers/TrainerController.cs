using BodyBuildingApp.Controllers.DTO;
using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils.Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BodyBuildingApp.Controllers
{
    [Route("/api/trainer")]
    [ApiController]
    public class TrainerController : Controller
    {
        private readonly ITrainerService trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            this.trainerService = trainerService;
        }
        [HttpGet("list")]
        public IActionResult GetListTrainer()
        {
            var list = trainerService.GetAllTrainer();
            if (list == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(list);
            }
        }
        [HttpGet("by_Id")]
        public ActionResult<Trainer> GetTrainerById(string id)
        {
            var trainer = trainerService.GetTrainerById(id);
            if (trainer == null)
            {
                return NotFound();
            }
            else
            {
                return trainer;
            }
        }
        [HttpPut("{id}")]
        public IActionResult HandleUpdateDTrainer([FromBody] AddTrainerDTO body, string id)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddTrainerDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var trainer = this.trainerService.GetTrainerById(id);

            if (trainer == null)
            {
                res.setErrorMessage("Cannot find Daily Food ");
                return new NotFoundObjectResult(res.getResponse());
            }

            trainer.Name = body.Name;
            trainer.Phone = body.Phone;
            trainer.Password = body.password;
            trainer.Role = body.role;
            trainer.Status = body.status;

            this.trainerService.UpdateTrainer(trainer);

            res.setMessage("Update trainer success");
            return new ObjectResult(res.getResponse());
        }
        [HttpPost]
        public IActionResult HandleAddTrainer([FromBody] AddTrainerDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddTrainerDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var trainer = new Trainer();
            trainer.TrainerId = Guid.NewGuid().ToString();
            trainer.Name = body.Name;
            trainer.Phone = body.Phone;
            trainer.Password = body.password;
            trainer.Role = body.role;
            trainer.Status = body.status;

            this.trainerService.CreateTrainer(trainer);
            res.setMessage("Add trainer success!");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete("{id}")]
        public IActionResult HandleDeleteTrainer(string id)
        {
            var res = new ServerApiResponse<string>();


            if (trainerService.DeleteTrainer(id) == false)
            {
                res.setErrorMessage("Cannot find dailyfood");
                return new NotFoundObjectResult(res.getResponse());
            }
            else
            {
                this.trainerService.DeleteTrainer(id);
                res.setMessage("Delete trainer success");
                return new ObjectResult(res.getResponse());
            }

        }
    }
}
