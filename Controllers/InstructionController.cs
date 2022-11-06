﻿using BodyBuildingApp.Auth;
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
    [Route("/api/Instruction")]
    [ApiController]
    public class InstructionController : Controller
    {
        private const string ExerciseSession = "ExerciseSession";
        private readonly IExerciseSessionService ExerciseSessionService;
        private readonly IExerciseService ExerciseService;
        private readonly IInstructionService InstructionService;
        private readonly IInstructionDetailService InstructionDetailService;
        public InstructionController(IExerciseSessionService exerciseSessionService, IInstructionService instructionService, IExerciseService exerciseService, IInstructionDetailService instructionDetailService)
        {
            this.ExerciseSessionService = exerciseSessionService;
            this.InstructionService = instructionService;
            this.ExerciseService = exerciseService;
            this.InstructionDetailService = instructionDetailService;
        }

        [HttpPost("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult CreateInstruction([FromBody] CreateInstructionDTO body)
        {
            var res = new ServerApiResponse<string>();
            string exerciseSession = this.HttpContext.Session.GetString(ExerciseSession);
            if (exerciseSession == null || exerciseSession == "")
            {
                res.setErrorMessage("There is no exercise had been chossen");
                return new BadRequestObjectResult(res.getResponse());
            }
            ValidationResult result = new CreateInstructionDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }
            float totalCalo = 0;
            float totalTime = 0;
            var list = this.ExerciseSessionService.convertStringToList(exerciseSession);
            foreach (var exerciseId in list)
            {
                Exercise exercise = this.ExerciseService.GetExercisebyId(exerciseId);
                totalCalo += exercise.CaloBurn;
                totalTime += (float)((exercise.Rep * 1.5)*exercise.Set);
            }
            
            Trainer trainer = (Trainer)ViewData["trainer"];

            Instruction instruction = new Instruction();
            instruction.InstructionId = Guid.NewGuid().ToString();
            instruction.TrainerId = trainer.TrainerId;
            instruction.TotalCalo = totalCalo;
            instruction.TotalTime = totalTime;
            instruction.Comment = body.Comment;
            instruction.Recommend = Recommend.RECOMMEND;

            this.InstructionService.CreateInstruction(instruction);

            foreach (var exerciseId in list)
            {
                
                InstructionDetail instructionDetail = new InstructionDetail();

                instructionDetail.InstructionDetailId = Guid.NewGuid().ToString();
                instructionDetail.InstructionId = instruction.InstructionId;
                instructionDetail.ExerciseId = exerciseId;
                this.InstructionDetailService.CreateInstructionDetail(instructionDetail);

            }


            this.HttpContext.Session.Remove(ExerciseSession);
            res.setMessage("Create instruction success");
            return new ObjectResult(res.getResponse());
        }
    }
}
