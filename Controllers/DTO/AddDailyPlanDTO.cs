using FluentValidation;
using System;
using System.Security.Cryptography.X509Certificates;

namespace BodyBuildingApp.Controllers.DTO
{

    public class UpdateDailyPlanDTO
    {
        public string Done { get; set; }
    }
    public class AddDailyPlan
    {
        public string DailyFoodDetailId { get; set; }
        public string InstructionId { get; set; }
    }
    public class AddDailyPlanValidator : AbstractValidator<AddDailyPlan>
    {
        public AddDailyPlanValidator()
        {
            RuleFor(x => x.DailyFoodDetailId).NotEmpty();
            RuleFor(x => x.InstructionId).NotEmpty();
        }
    }
    public class UpdateDailyPlanDTOValidator : AbstractValidator<UpdateDailyPlanDTO>
    {
        public UpdateDailyPlanDTOValidator()
        {
            RuleFor(x => x.Done).NotEmpty().MaximumLength(4);
        }
    }
}
