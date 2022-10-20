using BodyBuildingApp.Models;

namespace BodyBuildingApp.Repository.Interface
{
    public interface ITargetRepository
    {
        public Target GetTargetbyID(string targetId);

        public bool UpdateTarget(Target target);

        public bool DeleteTarget(Target targetId);
    }
}
