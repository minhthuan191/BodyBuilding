using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace BodyBuildingApp.Repository
{
    public class ScheduleRepository 
    {
        private readonly DBContext DBContext;
        public ScheduleRepository (DBContext dBContext)
        {
            this.DBContext = dBContext;
        }

        public Schedule GetScheduleById(string scheduleId)
        {
            Schedule schedule = this.DBContext.Schedule.FirstOrDefault(item => item.ScheduleId == scheduleId);
            if(schedule == null) return null;
            return schedule;
        }

        public Schedule GetScheduleByUserID(string userId)
        {
            Schedule schedule = this.DBContext.Schedule.FirstOrDefault(item => item.UserId == userId);
            if (schedule == null) return null;
            return schedule;
        }
        public bool CreateSchedule(Schedule schedule)
        {
            this.DBContext.Entry(schedule).State = EntityState.Modified;
            if(GetScheduleById(schedule.ScheduleId) != null)
            {
                this.DBContext.Schedule.Add(schedule);
                this.DBContext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("error at repository")
            }
        }
        public bool UpdateSchedule(Schedule schedule)
        {
            this.DBContext.Entry(schedule).State = EntityState.Modified;
            if (GetScheduleById(schedule.ScheduleId) == null) throw new Exception("error at repository");
            this.DBContext.Update(schedule);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool DeleteSchedule(string scheduleId)
        {
            var schedule = GetScheduleById(scheduleId);
            if (schedule == null) throw new Exception("error at repository");
            this.DBContext.Schedule.Remove(schedule);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
