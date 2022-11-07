﻿using BodyBuildingApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BodyBuildingApp.Service.Interface
{
    public interface IDailyPlanService
    {
        public List<DailyPlan> GetDailyPlanList();
        public DailyPlan GetDailybyPlanID(string id);
        public DailyPlan GetDailybyUserID(string id);
        public DailyPlan GetDailybyDate(string date);
        public bool CreateDailyPlan(DailyPlan dailyPlan);
        public bool UpdateDailyPlan(DailyPlan dailyPlan);
        public bool DeleteDailyPlan(string id);
    }
}
