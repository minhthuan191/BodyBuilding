using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Repository.Interface
{
    public interface IBodyStatusRepository
    {
        public BodyStatus GetBodyStatusByUserId(string userId);
        public BodyStatus GetBodyStatusByBodyID(string bodyid);
        public bool Updatebody(BodyStatus bodyStatus);

        public bool Deletebody(BodyStatus bodyid);

        public List<BodyStatus> GetAllBodyStatus();

    }
}
