using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System;
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

        public bool DeleteDailyFood(DailyFood dailyFood)
        {
            this.DBContext.DailyFood.Remove(dailyFood);
            this.DBContext.SaveChanges();
            return true;
        }
        public bool UpdateDailyFood(DailyFood dailyFood)
        {
            this.DBContext.DailyFood.Update(dailyFood);
            return this.DBContext.SaveChanges() > 0;
        }
        public bool CreateDailyFood(DailyFood dailyFood)
        {
                this.DBContext.DailyFood.Add(dailyFood);
                
                return this.DBContext.SaveChanges() > 0;
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
    }
}
