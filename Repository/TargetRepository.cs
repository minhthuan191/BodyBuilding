using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class TargetRepository 
    {
        private readonly DBContext DBContext;

        public TargetRepository(DBContext dBContext)
        {
            DBContext = dBContext;
        }

        public bool DeleteTarget(Target targetId)
        {
            this.DBContext.Remove(targetId);
            this.DBContext.SaveChanges();
            return true;
        }

        public Target GetTargetbyID(string targetId)
        {
            Target target = this.DBContext.Target.FirstOrDefault(item => item.TargetId == targetId);
            return target;
        }

        public bool UpdateTarget(Target target)
        {
            this.DBContext.Update(target);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
