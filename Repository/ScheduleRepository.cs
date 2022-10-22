using BodyBuildingApp.Models;
using BodyBuildingApp.Repository.Interface;
using BodyBuildingApp.Utils;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DBContext DBContext;
        public bool DeleteSchedule(string scheduleId)
        {
            this.DBContext.Remove(scheduleId);
            this.DBContext.SaveChanges();
            return true;
        }

        public Schedule GetScheduleById(string scheduleId)
        {
            Schedule schedule = this.DBContext.Schedule.FirstOrDefault(item => item.ScheduleId == scheduleId);
            return schedule;
        }

        public Schedule GetScheduleByUserID(string userId)
        {
            Schedule schedule = this.DBContext.Schedule.FirstOrDefault(item => item.UserId == userId);
            return schedule;
        }

        public bool UpdateSchedule(Schedule schedule)
        {
            this.DBContext.Update(schedule);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
