using BodyBuildingApp.Models;

namespace BodyBuildingApp.Repository.Interface
{
    public interface IFoodDetailRepository
    {
        public FoodDetail GetFoodbyName(string name);

        public FoodDetail GetFoodByCalories(string calories);

        public bool UpdateFoodDetail(FoodDetail foodDetail);

        public bool DeleteFoodDetail(FoodDetail foodDId);
    }
}
