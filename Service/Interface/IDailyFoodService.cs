﻿using BodyBuildingApp.Models;

namespace BodyBuildingApp.Service.Interface
{
    public interface IDailyFoodService
    {
        public DailyFood GetDailyFoodbyID(string foodId);

        public DailyFood GetFoodByTime(string timetoeat);

        public bool UpdateDailyFood(DailyFood dailyFood);

        public bool DeleteDailyFood(DailyFood foodid);

        public DailyFood GetDailyFoodByFoodName(string foodname);
    }
}
