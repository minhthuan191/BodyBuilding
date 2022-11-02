using BodyBuildingApp.Models;
using FluentValidation;

namespace BodyBuildingApp.Controllers.DTO
{
    
        public class AddDailyFoodDTO
        {
            public string FoodName { set; get; }
            public string TimeToEat { set; get; }
            public Recommend Recommend { set; get; }

        }
        public class AddDailyFoodDTOValidator : AbstractValidator<AddDailyFoodDTO>
        {
            public AddDailyFoodDTOValidator()
            {
                RuleFor(x => x.FoodName).NotEmpty().Length(1,50);
                RuleFor(x => x.TimeToEat).NotEmpty().Length(5,50);
                RuleFor(x => x.Recommend).NotEmpty();
            }
        }
    
}
