using BodyBuildingApp.Models;

namespace BodyBuildingApp.Service.Interface
{
    public interface IFoodDetailService
    {
        public FoodDetail GetFoodbyName(string name);

        public FoodDetail GetFoodByCalories(string calories);

        public bool UpdateFoodDetail(FoodDetail foodDetail);

        public bool DeleteFoodDetail(FoodDetail foodDId);
    }
}
