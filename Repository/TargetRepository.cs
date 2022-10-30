using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace BodyBuildingApp.Repository
{
    public class TargetRepository 
    {
        private readonly DBContext DBContext;

        public TargetRepository(DBContext dBContext)
        {
            DBContext = dBContext;
        }
        public Target GetTargetbyID(string targetId)
        {
            Target target = this.DBContext.Target.FirstOrDefault(item => item.TargetId == targetId);
            if(target== null) return null;
            return target;
        }
        public bool CreateTarget(Target target)
        {
            this.DBContext.Entry(target).State = EntityState.Modified;
            if(GetTargetbyID(target.TargetId) != null)
            {
                this.DBContext.Target.Add(target);
                this.DBContext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("error at repository");
            }
        }
        public bool UpdateTarget(Target target)
        {
            this.DBContext.Entry(target).State = EntityState.Modified;
            if (GetTargetbyID(target.TargetId) == null) throw new Exception("error at repository");
            this.DBContext.Update(target);
            this.DBContext.SaveChanges();
            return true;
        } 

        public bool DeleteTarget(string targetId)
        {
            var target = GetTargetbyID(targetId);
            if (target == null) throw new Exception("error at repository");
            this.DBContext.Target.Remove(target);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
