using FluentValidation;

namespace BodyBuildingApp.Controllers.DTO
{
    public class CreateTargetDTO
    {
        public string TargetName { get; set; }
    }

    public class CreateTargetDTOValidator : AbstractValidator<CreateTargetDTO>
    {
        public CreateTargetDTOValidator()

        {

            RuleFor(x => x.TargetName).NotEmpty().Length(1, 150);
        }
    }
}
