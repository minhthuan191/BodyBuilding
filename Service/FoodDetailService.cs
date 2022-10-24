using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;

namespace BodyBuildingApp.Service
{
    public class FoodDetailService : IFoodDetailService
    {
        private readonly FoodDetailRepository fdrepo;
        public FoodDetailService(FoodDetailRepository fsrepo)
        {
            this.fdrepo = fsrepo;
        }
        public bool DeleteFoodDetail(FoodDetail foodDId)
        {
            try
            {
                if (foodDId == null)
                {
                    throw new Exception("Error at get DeleteExcercise");
                }
                else
                {
                    return fdrepo.DeleteFoodDetail(foodDId);
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
                if (calories == null)
                {
                    throw new Exception("Error at get GetFoodByCalories");
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
                if (name == null)
                {
                    throw new Exception("Error at get GetFoodbyName");
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
                if (foodDetail == null)
                {
                    throw new Exception("Error at get UpdateFoodDetail");
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
