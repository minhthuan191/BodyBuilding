using BodyBuildingApp.Models;

namespace BodyBuildingApp.Repository.Interface
{
    public interface IScheduleRepository
    {
        public Schedule GetScheduleById(string scheduleId);

        public Schedule GetScheduleByUserID(string userId);

        public bool UpdateSchedule(Schedule schedule);

        public bool DeleteSchedule(string scheduleId);

    }
}
