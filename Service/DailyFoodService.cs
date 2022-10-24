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

        public bool DeleteDailyFood(DailyFood foodid)
        {
            try
            {
                if (foodid == null)
                    throw new Exception("Error at Delete Daily Food");
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
                if (foodname == null)
                    throw new Exception("Error at Get Daily Food By Name");
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
                if (foodId == null)
                    throw new Exception("Error at Get daily food by id");
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
                if (timetoeat == null)
                    throw new Exception("Error at Get Food By Time");
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
                if (dailyFood == null)
                    throw new Exception("Error at Update Daily Food");
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
