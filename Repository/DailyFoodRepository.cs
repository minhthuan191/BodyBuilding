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

        public bool DeleteDailyFood(string foodid)
        {
            var dailyfood = DBContext.DailyFood.FirstOrDefault(item => item.DailyFoodId == foodid);
            if (dailyfood == null) return false;
            this.DBContext.DailyFood.Remove(dailyfood);
            this.DBContext.SaveChanges();
            return true;
        }
        public bool UpdateDailyFood(DailyFood dailyFood)
        {
            this.DBContext.Entry(dailyFood).State = EntityState.Modified;
            if (GetDailyFoodbyID(dailyFood.DailyFoodId) == null) throw new Exception("id not exist");
            this.DBContext.DailyFood.Update(dailyFood);
            this.DBContext.SaveChanges();
            return true;
        }
        public bool CreateDailyFood(DailyFood dailyFood)
        {
            this.DBContext.Entry(dailyFood).State = EntityState.Modified;
            if(GetDailyFoodbyID(dailyFood.DailyFoodId) != null)
            {
                this.DBContext.DailyFood.Add(dailyFood);
                this.DBContext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("error at repository");
            }
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
    }
}
