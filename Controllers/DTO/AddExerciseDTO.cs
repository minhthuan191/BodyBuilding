using FluentValidation;

namespace BodyBuildingApp.Controllers.DTO
{
    public class AddExerciseDTO
    {

        public string ExerciseName { get; set; }
        public string Set { get; set; }
        public string BodyPart { get; set; }
        public string Step { get; set; }
        public string Rep { get; set; }
        public string CaloBurn { get; set; }

    }
    public class AddExerciseDTOValidator : AbstractValidator<AddExerciseDTO>
    {
        public AddExerciseDTOValidator()
        {
            RuleFor(x => x.ExerciseName).NotEmpty().Length(1,100);
            RuleFor(x => x.Set).NotEmpty().Length(1, 100);
            RuleFor(x => x.BodyPart).NotEmpty().Length(1, 50);
            RuleFor(x => x.Step).NotEmpty().Length(1, 150);
            RuleFor(x => x.Rep).NotEmpty().Length(1, 100);
            RuleFor(x => x.CaloBurn).NotEmpty().Length(1, 100);
        }
    }
}
