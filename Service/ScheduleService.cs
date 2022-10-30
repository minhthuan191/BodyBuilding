using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;

namespace BodyBuildingApp.Service
{
    public class ScheduleService : IScheduleService

    {
        private readonly ScheduleRepository schrepo;
        public ScheduleService(ScheduleRepository schrepo)
        {
            this.schrepo = schrepo;
        }

        public bool CreateSchedule(Schedule schedule)
        {
            if (schedule == null)
            {
                return false;
            }
            else
            {
                return schrepo.CreateSchedule(schedule);
            }
        }

        public bool DeleteSchedule(string scheduleId)
        {
            try
            {
                if (scheduleId == null)
                {
                    return false;
                }
                else
                {
                    return schrepo.DeleteSchedule(scheduleId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Schedule GetScheduleById(string scheduleId)
        {
            try
            {
                if (scheduleId == null || schrepo.GetScheduleById(scheduleId) == null)
                {
                    return null;
                }
                else
                {
                    return schrepo.GetScheduleById(scheduleId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Schedule GetScheduleByUserID(string userId)
        {
            try
            {
                if (userId == null || schrepo.GetScheduleByUserID(userId) == null)
                {
                    return null;
                }
                else
                {
                    return schrepo.GetScheduleByUserID(userId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateSchedule(Schedule schedule)
        {
            try
            {
                if (schedule == null)
                {
                    return false ;
                }
                else
                {
                    return schrepo.UpdateSchedule(schedule);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
