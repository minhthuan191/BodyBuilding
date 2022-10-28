using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Collections.Generic;
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

        public bool UpdateDailyPlan(DailyPlan dailyPlan)
        {
            if (GetDailybyPlanID(dailyPlan.PlanId) == null) return false;
            this.DBContext.DailyPlan.Update(dailyPlan);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool DeleteDailyPlan(string id)
        {
            if (GetDailybyPlanID(id) == null) return false;
            this.DBContext.Remove(id);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
