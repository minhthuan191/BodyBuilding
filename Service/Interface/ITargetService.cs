using BodyBuildingApp.Models;

namespace BodyBuildingApp.Service.Interface
{
    public interface ITargetService
    {
        public Target GetTargetbyID(string targetId);

        public bool UpdateTarget(Target target);

        public bool DeleteTarget(Target targetId);
    }
}
