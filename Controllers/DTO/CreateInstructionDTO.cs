using FluentValidation;

namespace BodyBuildingApp.Controllers.DTO
{
    public class CreateInstructionDTO
    {
        public string Comment { get; set; }

    }
    public class CreateInstructionDTOValidator : AbstractValidator<CreateInstructionDTO>
    {
        public CreateInstructionDTOValidator()

        {

            RuleFor(x => x.Comment).NotEmpty().Length(1, 150);
        }
    }
}
