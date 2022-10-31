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

        public bool DeleteBody(string id)
        {
            var bodystatus =  DBContext.BodyStatus.FirstOrDefault(x => x.BodyStatusId == id);
            if (bodystatus != null)
            {
                DBContext.BodyStatus.Remove(bodystatus);
                DBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
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
            
            if(GetBodyStatusByBodyID(bodyStatus.BodyStatusId) != null) 
            {
                throw new Exception("Id is exist");
            }
            else
            {
                this.DBContext.BodyStatus.Add(bodyStatus);
                this.DBContext.SaveChanges();
                return true;
            }
        }

        public bool Updatebody(BodyStatus bodyStatus)
        {
            this.DBContext.Entry(bodyStatus).State = EntityState.Modified;
            if (GetBodyStatusByBodyID(bodyStatus.BodyStatusId) == null)
            {
                throw new Exception ("Id is not exist");
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
