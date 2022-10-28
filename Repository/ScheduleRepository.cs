using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class ScheduleRepository 
    {
        private readonly DBContext DBContext;
        public ScheduleRepository (DBContext dBContext)
        {
            this.DBContext = dBContext;
        }
        public bool DeleteSchedule(string scheduleId)
        {
            if (GetScheduleById(scheduleId) == null) return false;
            this.DBContext.Remove(scheduleId);
            this.DBContext.SaveChanges();
            return true;
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

        public bool UpdateSchedule(Schedule schedule)
        {
            if (GetScheduleById(schedule.ScheduleId) == null) return false;
            this.DBContext.Update(schedule);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
