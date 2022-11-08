using BodyBuildingApp.Models;
using FluentValidation;

namespace BodyBuildingApp.Controllers.DTO
{
    
        public class AddDailyFoodDetailDTO
        {  
            public string foodName { set; get; }
            public string TimeToEat { set; get; }
            public Recommend Recommend { set; get; }

        }
        public class AddDailyFoodDetailDTOValidator : AbstractValidator<AddDailyFoodDetailDTO>
        {
            public AddDailyFoodDetailDTOValidator()
            {
            RuleFor(x => x.foodName).NotEmpty().Length(1, 50);
            RuleFor(x => x.TimeToEat).NotEmpty().Length(1,50);
            RuleFor(x => x.Recommend).NotEmpty();
            }
        }
    //public class UpdateDailyFoodDetailDTO
    //{
    //    public string TimeToEat { set; get; }
    //    public Recommend Recommend { set; get; }

    //}
    //public class UpdateDailyFoodDetailDTOValidator : AbstractValidator<UpdateDailyFoodDetailDTO>
    //{
    //    public UpdateDailyFoodDetailDTOValidator()
    //    {
    //        RuleFor(x => x.TimeToEat).NotEmpty().Length(5, 50);
    //        RuleFor(x => x.Recommend).NotEmpty();
    //    }
    //}

}
