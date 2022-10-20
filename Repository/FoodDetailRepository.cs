using BodyBuildingApp.Models;
using BodyBuildingApp.Repository.Interface;
using BodyBuildingApp.Utils;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class FoodDetailRepository : IFoodDetailRepository
    {
        private readonly DBContext DBContext;
        public bool DeleteFoodDetail(FoodDetail foodDId)
        {
            this.DBContext.Remove(foodDId);
            this.DBContext.SaveChanges();
            return true;
        }

        public FoodDetail GetFoodByCalories(string calories)
        {
            FoodDetail foodDetail = this.DBContext.FoodDetail.FirstOrDefault(item => item.Calories.Equals(calories));
            return foodDetail;
        }

        public FoodDetail GetFoodbyName(string name)
        {
            FoodDetail foodDetail = this.DBContext.FoodDetail.FirstOrDefault(item => item.FoodName == name);
            return foodDetail;
        }

        public bool UpdateFoodDetail(FoodDetail foodId)
        {
            this.DBContext.Update(foodId);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
