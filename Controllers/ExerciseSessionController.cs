using BodyBuildingApp.Utils.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using BodyBuildingApp.Service;
using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;

namespace BodyBuildingApp.Controllers
{
    [Route("/api/exerciseSession")]
    [ApiController]
    public class ExerciseSessionController : Controller
    {
        private const string ExerciseSession = "ExerciseSession";
        private readonly IExerciseSessionService ExerciseSessionService;
        private readonly IExerciseService ExerciseService;

        
        public ExerciseSessionController( IExerciseSessionService exerciseSessionService, IExerciseService exerciseService)
        {
            this.ExerciseSessionService = exerciseSessionService;
            this.ExerciseService = exerciseService;
        }
        [HttpPost("add")]
        public IActionResult HandleAddToExerciseSession(string id)
        {
            var res = new ServerApiResponse<object>();

            string exerciseSession = this.HttpContext.Session.GetString(ExerciseSession);
            List<string> listExerciseId = this.ExerciseSessionService.convertStringToList(exerciseSession);
            
            if (listExerciseId == null)
            {
                listExerciseId = new List<string>();
            }

            Exercise exercise = this.ExerciseService.GetExercisebyId(id);
            if (exercise == null)
            {
                this.HttpContext.Session.SetString(ExerciseSession, this.ExerciseSessionService.convertListToString(listExerciseId));
                res.setErrorMessage("Can not find this exercise");
                return new BadRequestObjectResult(res.getResponse());
            }

            foreach (var item in listExerciseId)
            {
                if (item == id)
                {
                    this.HttpContext.Session.SetString(ExerciseSession, this.ExerciseSessionService.convertListToString(listExerciseId));
                    res.setErrorMessage("This exercise already have in this daily plan");
                    return new BadRequestObjectResult(res.getResponse());
                }
            }

            listExerciseId.Add(id);
            this.HttpContext.Session.SetString(ExerciseSession, this.ExerciseSessionService.convertListToString(listExerciseId));

            res.data = this.ExerciseSessionService.GetListExercise(listExerciseId);
            res.setMessage("Add success");
            return new ObjectResult(res.getResponse());
        }

        [HttpGet("")]
        public IActionResult handleOnGetExerciseSession()
        {
            var res = new ServerApiResponse<object>();
            var exerciseSession = this.HttpContext.Session.GetString(ExerciseSession) ?? "";

            var listExerciseId = this.ExerciseSessionService.convertStringToList(exerciseSession);

            var listExercise = this.ExerciseSessionService.GetListExercise(listExerciseId);

            res.data = listExercise;

            return new ObjectResult(res.getResponse());
        }
    }
}
