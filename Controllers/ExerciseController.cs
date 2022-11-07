using BodyBuildingApp.Auth;
using BodyBuildingApp.Controllers.DTO;
using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils.Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Controllers
{
    [Route("/api/Exercise")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }
        [HttpGet("{id}")]
        public Exercise GetExercisebyId(string id)
        {
            if (exerciseService.GetExercisebyId(id) == null)
            {
                throw new Exception(" Id not found or not exist");
            }
            else
            {
                return exerciseService.GetExercisebyId(id);
            }
        }
        [HttpGet("list")]
        public (List<Exercise>,int) GetListExercise(int pageIndex, int pageSize)
        {
            if (exerciseService.GetListExercise(pageIndex, pageSize) == (null, 0))
            {
                throw new Exception("Fail to get list");
            }
            else
            {
                return exerciseService.GetListExercise(pageIndex,pageSize);
            }
        }

        [HttpPut]
        public IActionResult HandleUpdateExercise([FromBody] CreateExerciseDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new CreateExerciseDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var exercise = this.exerciseService.GetExercisebyId(body.ExerciseId);

            if (exercise == null)
            {
                res.setErrorMessage("Cannot find this exercise");
                return new NotFoundObjectResult(res.getResponse());
            }

            exercise.Set = body.Set;
            exercise.Rep = body.Rep;
            exercise.BodyPart = body.BodyPart;
            exercise.CaloBurn = body.CaloBurn;
            exercise.Step = body.Step;

            this.exerciseService.UpdateExcercise(exercise);

            res.setMessage("Update exercise success");
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        public IActionResult HandleAddExercise([FromBody] AddExerciseDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new AddExerciseDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            };

            var exercise = new Exercise();

            exercise.ExerciseId = Guid.NewGuid().ToString();
            exercise.Set = body.Set;
            exercise.Rep = body.Rep;
            exercise.CaloBurn = body.CaloBurn;
            exercise.BodyPart = body.BodyPart;
            exercise.Step = body.Step;

            this.exerciseService.CreateExcercise(exercise);
            res.setMessage("Add excercise success!");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete]
        public IActionResult HandleDeleteExercise(string id)
        {
            var res = new ServerApiResponse<string>();

            var exercise = this.exerciseService.GetExercisebyId(id);

            if (exercise == null)
            {
                res.setErrorMessage("Cannot find exercise");
                return new NotFoundObjectResult(res.getResponse());
            }

            this.exerciseService.DeleteExcercise(exercise);

            res.setMessage("Delete exercise success");
            return new ObjectResult(res.getResponse());
        }
    }
}
