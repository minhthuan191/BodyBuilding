using FluentValidation;

namespace BodyBuildingApp.Controllers.DTO
{
   
        public class AddBodyStatusDTO
        {
            public float Weight { set; get; }
            public float Height { set; get; }

        }
        public class AddBodyStatusDTOValidator : AbstractValidator<AddBodyStatusDTO>
        {
            public AddBodyStatusDTOValidator()
            {
                RuleFor(x => x.Weight).NotEmpty().GreaterThan(0);
                RuleFor(x => x.Height).NotEmpty().GreaterThan(0);

            }
        }
    
}
