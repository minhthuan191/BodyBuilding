using BodyBuildingApp.Models;

namespace BodyBuildingApp.Service.Interface
{
    public interface ISessionService
    {
        public Session GetSessionById(string sessionId);

        public bool CreateSession(Session session);

        public bool UpdateSession(Session session);

        public bool DeleteSession(string sessionId);
    }
}
