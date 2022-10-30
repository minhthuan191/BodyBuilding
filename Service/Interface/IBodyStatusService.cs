using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface IBodyStatusService
    {
        public BodyStatus GetBodyStatusByUserId(string userId);
        public BodyStatus GetBodyStatusByBodyID(string bodyid);
        public bool Updatebody(BodyStatus bodyStatus);

        public bool Createbody(BodyStatus bodyStatus);

        public bool Deletebody(string id);

        public List<BodyStatus> GetAllBodyStatus();

    }
}
