using BodyBuildingApp.Models;

namespace BodyBuildingApp.Service.Interface
{
    public interface IScheduleService
    {
        public Schedule GetScheduleById(string scheduleId);

        public Schedule GetScheduleByUserID(string userId);

        public bool UpdateSchedule(Schedule schedule);

        public bool DeleteSchedule(string scheduleId);

    }
}
