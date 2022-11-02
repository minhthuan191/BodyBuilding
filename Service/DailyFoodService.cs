using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;

namespace BodyBuildingApp.Service
{
    public class DailyFoodService : IDailyFoodService
    {
        private readonly DailyFoodRepository dfrepo;

        public DailyFoodService(DailyFoodRepository dfrepo)
        {
            this.dfrepo = dfrepo;
        }

        public bool CreateDailyFood(DailyFood dailyFood)
        {
            
            return dfrepo.CreateDailyFood(dailyFood);
            
        }

        public bool DeleteDailyFood(DailyFood dailyFood)
        { 
            return dfrepo.DeleteDailyFood(dailyFood);
           
        }


        public DailyFood GetDailyFoodbyID(string foodId)
        {
            return dfrepo.GetDailyFoodbyID(foodId);
            
        }

        public DailyFood GetFoodByTime(string timetoeat)
        {   
            return dfrepo.GetFoodByTime(timetoeat);
        }

        public bool UpdateDailyFood(DailyFood dailyFood)
        {
            return dfrepo.UpdateDailyFood(dailyFood);
        }
    }
}
