using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
            if (target == null) return null;
            return target;
        }
        public List<Target> GetAllTarget()
        {
            List<Target> listTarget = this.DBContext.Set<Target>().ToList<Target>();
            return listTarget;
        }
        public bool CreateTarget(Target target)
        {
            this.DBContext.Target.Add(target);
            this.DBContext.SaveChanges();
            return true;

        }
        public bool UpdateTarget(Target target)
        {
            this.DBContext.Update(target);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool DeleteTarget(Target target)
        {
            this.DBContext.Target.Remove(target);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
