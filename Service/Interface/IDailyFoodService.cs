using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface IDailyFoodService
    {
        public List<DailyFood> GetDailyFoodList();
        public DailyFood GetDailyFoodbyID(string foodId);

        public DailyFood GetFoodByTime(string timetoeat);

        public bool CreateDailyFood(DailyFood dailyFood);

        public bool UpdateDailyFood(DailyFood dailyFood);

        public bool DeleteDailyFood(string dailyFood);

    }
}
