using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BodyBuildingApp.Service
{
    public class FoodDetailService : IFoodDetailService
    {
        private readonly FoodDetailRepository fdrepo;
        public FoodDetailService(FoodDetailRepository fsrepo)
        {
            this.fdrepo = fsrepo;
        }

        public bool CreateFoodDetail(FoodDetail foodDetail)
        {
           
                return fdrepo.CreateFoodDetail(foodDetail);
            
        }

        public bool DeleteFoodDetail(string foodname)
        {
            
                
                    return fdrepo.DeleteFoodDetail(foodname);
            
        }

        public FoodDetail GetFoodByCalories(string calories)
        {
            
                    return fdrepo.GetFoodByCalories(calories);
             
        }

        public FoodDetail GetFoodbyName(string name)
        {
           
                    return fdrepo.GetFoodbyName(name);
            
        }

        public List<FoodDetail> GetListFoodDetail()
        { 
           return fdrepo.GetAllFoodDetail();
        }

        public bool UpdateFoodDetail(FoodDetail foodDetail)
        {
            
                    return fdrepo.UpdateFoodDetail(foodDetail);
            
        }
    }
}
