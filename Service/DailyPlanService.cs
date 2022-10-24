using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;

namespace BodyBuildingApp.Service
{
    public class DailyPlanService : IDailyPlanService
    {
        private readonly DailyPlanRepository dlrepo;
        public DailyPlanService(DailyPlanRepository dlrepo)
        {
            this.dlrepo = dlrepo;
        }

        public bool DeleteDailyPlan(string id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Error at DeleteDailyPlan");
                else
                {
                    return dlrepo.DeleteDailyPlan(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DailyPlan GetDailybyDate(string date)
        {
            try
            {
                if (date == null)
                    throw new Exception("Error at GetDailybyDate");
                else
                {
                    return dlrepo.GetDailybyDate(date);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DailyPlan GetDailybyPlanID(string id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Error at GetDailybyPlanID");
                else
                {
                    return dlrepo.GetDailybyPlanID(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DailyPlan GetDailybyUserID(string id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Error at GetDailybyUserID");
                else
                {
                    return dlrepo.GetDailybyUserID(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateDailyPlan(DailyPlan dailyPlan)
        {
            try
            {
                if (dailyPlan == null)
                    throw new Exception("Error at UpdateDailyPlan");
                else
                {
                    return dlrepo.UpdateDailyPlan(dailyPlan);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
