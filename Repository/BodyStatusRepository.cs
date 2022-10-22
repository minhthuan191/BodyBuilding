using BodyBuildingApp.Models;
using BodyBuildingApp.Repository.Interface;
using BodyBuildingApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class BodyStatusRepository : IBodyStatusRepository
    {
        private readonly DBContext DBContext;
        public bool Deletebody(BodyStatus bodyid)
        {
            try {
                this.DBContext.BodyStatus.Remove(bodyid);
                return true;
            } catch(Exception ex)
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
            return bodystatus;
        }

        public BodyStatus GetBodyStatusByUserId(string userId)
        {
            BodyStatus bodystatus = this.DBContext.BodyStatus.FirstOrDefault(item => item.UserId == userId);
            return bodystatus;

        }

        public bool Updatebody(BodyStatus bodyStatus)
        {
            this.DBContext.BodyStatus.Update(bodyStatus);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
