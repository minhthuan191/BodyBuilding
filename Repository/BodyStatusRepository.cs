using BodyBuildingApp.Models;
using BodyBuildingApp.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class BodyStatusRepository 
    {
        private readonly DBContext DBContext;
        public BodyStatusRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }

        public bool DeleteBody(BodyStatus bodyStatus)
        {
                DBContext.BodyStatus.Remove(bodyStatus);
                return DBContext.SaveChanges() > 0;
        }

        public List<BodyStatus> GetAllBodyStatus()
        {
            List<BodyStatus> list = this.DBContext.Set<BodyStatus>().ToList<BodyStatus>();
            return list;
        }
         
        public BodyStatus GetBodyStatusByBodyID(string bodyid)
        {
            BodyStatus bodystatus = this.DBContext.BodyStatus.FirstOrDefault(item => item.BodyStatusId == bodyid);
            if (bodystatus == null) return null;
            return bodystatus;
        }



        public BodyStatus GetBodyStatusByUserId(string userId)
        {
            BodyStatus bodystatus = this.DBContext.BodyStatus.FirstOrDefault(item => item.UserId == userId);
            if (bodystatus == null) return null;
            return bodystatus;

        }

        public bool CreateBodyStatus(BodyStatus bodyStatus)
        {
             this.DBContext.BodyStatus.Add(bodyStatus);
             return this.DBContext.SaveChanges() > 0;
                
            
        }

        public bool Updatebody(BodyStatus bodyStatus)
        {
            
            if (bodyStatus == null)
            {
                return false;
            }
            else
            {
                this.DBContext.BodyStatus.Update(bodyStatus);
                this.DBContext.SaveChanges();
                return true;
            }

        }
    }
}
