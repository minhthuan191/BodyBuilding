using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class FoodDetailRepository
    {
        private readonly DBContext DBContext;
        public FoodDetailRepository(DBContext dBContext)
        {
            DBContext = dBContext;
        }

        public bool DeleteFoodDetail(string foodname)
        {
            if (GetFoodbyName(foodname) == null) return false;
            this.DBContext.Remove(foodname);
            this.DBContext.SaveChanges();
            return true;
        }

        public FoodDetail GetFoodByCalories(string calories)
        {
            FoodDetail foodDetail = this.DBContext.FoodDetail.FirstOrDefault(item => item.Calories.Equals(calories));
            if (foodDetail == null) return null; 
            return foodDetail;
        }

        public FoodDetail GetFoodbyName(string name)
        {
            FoodDetail foodDetail = this.DBContext.FoodDetail.FirstOrDefault(item => item.FoodName == name);
            if(foodDetail == null) return null;
            return foodDetail;
        }

        public bool UpdateFoodDetail(FoodDetail food)
        {
            if (GetFoodbyName(food.FoodName) == null) return false;
            this.DBContext.Update(food);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
