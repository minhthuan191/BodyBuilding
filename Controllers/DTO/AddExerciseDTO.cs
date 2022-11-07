using FluentValidation;

namespace BodyBuildingApp.Controllers.DTO
{
    public class AddExerciseDTO
    {
        public string ExeciseName { get; set; }
        public int Set { get; set; }
        public string BodyPart { get; set; }
        public string Step { get; set; }
        public int Rep { get; set; }
        public float CaloBurn { get; set; }

    }
    public class AddExerciseDTOValidator : AbstractValidator<AddExerciseDTO>
    {
        public AddExerciseDTOValidator()
        {
            RuleFor(x => x.ExeciseName).NotEmpty().Length(1,100);
            RuleFor(x => x.Set).NotEmpty().GreaterThan(0);
            RuleFor(x => x.BodyPart).NotEmpty().Length(1, 50);
            RuleFor(x => x.Step).NotEmpty();
            RuleFor(x => x.Rep).NotEmpty().GreaterThan(0);
            RuleFor(x => x.CaloBurn).NotEmpty().GreaterThan(0);
        }
    }
}
