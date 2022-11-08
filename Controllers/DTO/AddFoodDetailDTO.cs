using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BodyBuildingApp.Controllers.DTO
{
    public class AddFoodDetailDTO
    {
        public string FoodName { get; set; }
        public float calories { get; set; }
        public IFormFile image { get; set; }
    }
    public class AddFoodDetailDTOValidator : AbstractValidator<AddFoodDetailDTO>
    {
        public AddFoodDetailDTOValidator()
        {
            RuleFor(x => x.FoodName).NotEmpty();
            RuleFor(x => x.calories).NotEmpty().GreaterThan(0);

        }
    }
    public class UpdateFoodDetailDTO
    {
        public float calories { get; set; }
    }
    public class UpdateFoodDetailDTOValidator : AbstractValidator<UpdateFoodDetailDTO>
    {
        public UpdateFoodDetailDTOValidator()
        {
            RuleFor(x => x.calories).NotEmpty().GreaterThan(0);

        }
    }
}
