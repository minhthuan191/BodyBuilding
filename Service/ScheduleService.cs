﻿using BodyBuildingApp.Models;
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

        public bool DeleteSchedule(string scheduleId)
        {
            try
            {
                if (scheduleId == null)
                {
                    throw new Exception("Error at get DeleteSchedule");
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
                if (scheduleId == null)
                {
                    throw new Exception("Error at get GetScheduleById");
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
                if (userId == null)
                {
                    throw new Exception("Error at get GetScheduleByUserID");
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
                    throw new Exception("Error at get UpdateSchedule");
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
