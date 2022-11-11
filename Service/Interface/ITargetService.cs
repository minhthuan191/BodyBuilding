using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface ITargetService
    {
        public Target GetTargetbyUserId(string userId);
        public Target GetTargetbyID(string targetId);
        public List<Target> GetAllTarget();

        public bool CreateTarget(Target target);

        public bool UpdateTarget(Target target);

        public bool DeleteTarget(Target target);
    }
}
