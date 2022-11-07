using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Repository
{
    public class FoodDetailRepository
    {
        private readonly DBContext DBContext;
        public FoodDetailRepository(DBContext dBContext)
        {
            DBContext = dBContext;
        }
        
        public List<FoodDetail> GetAllFoodDetail()
        {
            List<FoodDetail> list = this.DBContext.Set<FoodDetail>().ToList<FoodDetail>();
            if (list == null) return null;
            else return list;
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
        public bool CreateFoodDetail(FoodDetail food)
        {
            this.DBContext.Entry(food).State = EntityState.Modified;
            if(GetFoodbyName(food.FoodName) == null)
            {
                this.DBContext.FoodDetail.Add(food);
                this.DBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateFoodDetail(FoodDetail food)
        {
            this.DBContext.Entry(food).State = EntityState.Modified;
            if (GetFoodbyName(food.FoodName) == null) return false; 
            this.DBContext.Update(food);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool DeleteFoodDetail(string foodname)
        {
            var fooddetail = GetFoodbyName(foodname);
            if (fooddetail == null) return false;
            this.DBContext.FoodDetail.Remove(fooddetail);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
