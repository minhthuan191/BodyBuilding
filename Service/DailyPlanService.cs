using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Service
{
    public class DailyPlanService : IDailyPlanService
    {
        private readonly DailyPlanRepository dlrepo;
        public DailyPlanService(DailyPlanRepository dlrepo)
        {
            this.dlrepo = dlrepo;
        }

        public bool CreateDailyPlan(DailyPlan dailyPlan)
        {
            if (dailyPlan == null )
                return false;
            else
            {
                return dlrepo.CreateDailyPlan(dailyPlan);
            };
        }

        public bool DeleteDailyPlan(string id)
        {
            try
            {
                if (id == null )
                    return false;
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
                if (date == null || dlrepo.GetDailybyDate(date) == null)
                    return null ;
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
                if (id == null || dlrepo.GetDailybyPlanID(id) == null)
                    return null;
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
                if (id == null || dlrepo.GetDailybyUserID(id) == null)
                    return null;
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

        public List<DailyPlan> GetDailyPlanList()
        {
            return dlrepo.GetDailyPlans();
        }

        public bool UpdateDailyPlan(DailyPlan dailyPlan)
        {
            try
            {
                if (dailyPlan == null)
                    return false;
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
