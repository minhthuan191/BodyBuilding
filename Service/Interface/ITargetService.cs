using BodyBuildingApp.Models;

namespace BodyBuildingApp.Service.Interface
{
    public interface ITargetService
    {
        public Target GetTargetbyID(string targetId);

        public bool CreateTarget(Target target);

        public bool UpdateTarget(Target target);

        public bool DeleteTarget(string targetId);
    }
}
