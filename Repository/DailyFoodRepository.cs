using BodyBuildingApp.Models;
using BodyBuildingApp.Repository.Interface;
using BodyBuildingApp.Utils;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class DailyFoodRepository : IDailyFoodRepository
    {
        private readonly DBContext DBContext;
        public bool DeleteDailyFood(DailyFood foodid)
        {
            this.DBContext.DailyFood.Remove(foodid);
            this.DBContext.SaveChanges();
            return true;
        }

        public DailyFood GetDailyFoodByFoodName(string foodname)
        {
            DailyFood food = this.DBContext.DailyFood.FirstOrDefault(item => item.FoodName == foodname);
            return food;
        }

        public DailyFood GetDailyFoodbyID(string foodId)
        {
            DailyFood food = this.DBContext.DailyFood.FirstOrDefault(item => item.DailyFoodId == foodId);
            return food;

        }

        public DailyFood GetFoodByTime(string timetoeat)
        {
            DailyFood food = this.DBContext.DailyFood.FirstOrDefault(item => item.TimetoEat == timetoeat);
            return food;

        }

        public bool UpdateDailyFood(DailyFood dailyFood)
        {
            this.DBContext.Update(dailyFood);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
