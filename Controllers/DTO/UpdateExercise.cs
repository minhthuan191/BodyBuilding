using FluentValidation;

namespace BodyBuildingApp.Controllers.DTO
{
    public class CreateExerciseDTO
    {
        public string ExerciseId { get; set; }
        public string Set { get; set; }
        public string BodyPart { get; set; }
        public string Step { get; set; }
        public string Rep { get; set; }
        public float CaloBurn { get; set; }

    }
    public class CreateExerciseDTOValidator : AbstractValidator<CreateExerciseDTO>
    {
        public CreateExerciseDTOValidator()
        {
            RuleFor(x => x.ExerciseId).NotEmpty();
            RuleFor(x => x.Set).NotEmpty().Length(1, 50);
            RuleFor(x => x.BodyPart).NotEmpty().Length(1, 50);
            RuleFor(x => x.Step).NotEmpty().Length(1, 150);
            RuleFor(x => x.Rep).NotEmpty().Length(1, 50);
            RuleFor(x => x.CaloBurn).NotEmpty().GreaterThan(0);
        }
    }
}
