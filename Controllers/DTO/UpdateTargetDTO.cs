using FluentValidation;

namespace BodyBuildingApp.Controllers.DTO
{
    public class UpdateTargetDTO
    {
        public string TargetId { get; set; }
        public string TargetName { get; set; }
    }

    public class UpdateTargetDTOValidator : AbstractValidator<UpdateTargetDTO>
    {
        public UpdateTargetDTOValidator()

        {
            RuleFor(x => x.TargetId).NotEmpty();
            RuleFor(x => x.TargetName).NotEmpty().Length(1, 150);
        }
    }
}
