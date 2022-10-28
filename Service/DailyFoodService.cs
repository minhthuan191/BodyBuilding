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

        public bool DeleteDailyFood(string foodid)
        {
            try
            {
                if (foodid == null || dfrepo.GetDailyFoodbyID(foodid) == null)
                    return false;
                else
                {
                    return dfrepo.DeleteDailyFood(foodid);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DailyFood GetDailyFoodByFoodName(string foodname)
        {
            try
            {
                if (foodname == null || dfrepo.GetDailyFoodByFoodName(foodname) == null)
                    return null;
                else
                {
                    return dfrepo.GetDailyFoodByFoodName(foodname);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DailyFood GetDailyFoodbyID(string foodId)
        {
            try
            {
                if (foodId == null || dfrepo.GetDailyFoodbyID(foodId) == null)
                    return null;
                else
                {
                    return dfrepo.GetDailyFoodbyID(foodId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DailyFood GetFoodByTime(string timetoeat)
        {
            try
            {
                if (timetoeat == null || dfrepo.GetFoodByTime(timetoeat) == null)
                    return null;
                else
                {
                    return dfrepo.GetFoodByTime(timetoeat);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateDailyFood(DailyFood dailyFood)
        {
            try
            {
                if (dailyFood == null || dfrepo.GetDailyFoodbyID(dailyFood.DailyFoodId) == null)
                    return false;
                else
                {
                    return dfrepo.UpdateDailyFood(dailyFood);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
