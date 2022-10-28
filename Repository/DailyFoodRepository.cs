using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class DailyFoodRepository 
    {
        private readonly DBContext DBContext;
        public DailyFoodRepository(DBContext dBContext)
        {
            DBContext = dBContext;
        }

        public bool DeleteDailyFood(string foodid)
        {
            if (GetDailyFoodbyID(foodid) == null) return false;
            this.DBContext.Remove(foodid);
            this.DBContext.SaveChanges();
            return true;
        }

        public DailyFood GetDailyFoodByFoodName(string foodname)
        {
            DailyFood food = this.DBContext.DailyFood.FirstOrDefault(item => item.FoodName == foodname);
            if(food == null) return null;
            return food;
        }

        public DailyFood GetDailyFoodbyID(string foodId)
        {
            DailyFood food = this.DBContext.DailyFood.FirstOrDefault(item => item.DailyFoodId == foodId);
            if (food == null) return null; 
            return food;

        }

        public DailyFood GetFoodByTime(string timetoeat)
        {
            DailyFood food = this.DBContext.DailyFood.FirstOrDefault(item => item.TimetoEat == timetoeat);
            if (food == null) return null;
            return food;

        }

        public bool UpdateDailyFood(DailyFood dailyFood)
        {
            if (GetDailyFoodbyID(dailyFood.DailyFoodId) == null) return false;
            this.DBContext.Update(dailyFood);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
