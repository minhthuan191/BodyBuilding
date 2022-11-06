using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using Microsoft.EntityFrameworkCore;
using BodyBuildingApp.Utils;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class DailyPlanRepository
    { 

        private readonly DBContext DBContext;
        public DailyPlanRepository(DBContext dBContext)
        {
        this.DBContext = dBContext;
        }

        public DailyPlan GetDailybyPlanID(string id)
        {
            DailyPlan dailyPlan = this.DBContext.DailyPlan.FirstOrDefault(item => item.PlanId == id);
            if (dailyPlan == null) return null;
            return dailyPlan;
        }

        public DailyPlan GetDailybyUserID(string id)
        {
            DailyPlan dailyPlan = this.DBContext.DailyPlan.FirstOrDefault(item => item.UserId == id);
            if(dailyPlan == null) return null;
            return dailyPlan;
        }

        public DailyPlan GetDailybyDate(string date)
        {
            DailyPlan dailyPlan = this.DBContext.DailyPlan.FirstOrDefault(item => item.Date == date);
            if(dailyPlan == null) return null;
            return dailyPlan;
        }
        public bool CreateDailyPlan(DailyPlan dailyPlan)
        {
            this.DBContext.Entry(dailyPlan).State = EntityState.Modified;
            if(GetDailybyPlanID(dailyPlan.PlanId) == null)
            {
                this.DBContext.DailyPlan.Add(dailyPlan);
                this.DBContext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("error at repository");
            }
        }

        public bool UpdateDailyPlan(DailyPlan dailyPlan)
        {
            DBContext.Entry(dailyPlan).State = EntityState.Modified;
            if (GetDailybyPlanID(dailyPlan.PlanId) == null) throw new Exception("error at repository");
            this.DBContext.DailyPlan.Update(dailyPlan);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool DeleteDailyPlan(string id)
        {
            var dailyplan = GetDailybyPlanID(id);
            if (dailyplan == null)
            {
                return false;
            }
            else
            {
                this.DBContext.DailyPlan.Remove(dailyplan);
                this.DBContext.SaveChanges();
                return true;
            }
        }
    }
}
