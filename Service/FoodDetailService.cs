using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;
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
        public bool DeleteFoodDetail(string foodname)
        {
            try
            {
                if (foodname == null || fdrepo.GetFoodbyName(foodname) == null)
                {
                    return false;
                }
                else
                {
                    return fdrepo.DeleteFoodDetail(foodname);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public FoodDetail GetFoodByCalories(string calories)
        {
            try
            {
                if (calories == null || fdrepo.GetFoodByCalories(calories) == null)
                {
                    return null;
                }
                else
                {
                    return fdrepo.GetFoodByCalories(calories);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public FoodDetail GetFoodbyName(string name)
        {
            try
            {
                if (name == null || fdrepo.GetFoodbyName(name) == null) 
                {
                    return null;
                }
                else
                {
                    return fdrepo.GetFoodbyName(name);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateFoodDetail(FoodDetail foodDetail)
        {
            try
            {
                if (foodDetail == null || fdrepo.GetFoodbyName(foodDetail.FoodName) == null)
                {
                    return false;
                }
                else
                {
                    return fdrepo.UpdateFoodDetail(foodDetail);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
