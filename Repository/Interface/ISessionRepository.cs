using BodyBuildingApp.Models;

namespace BodyBuildingApp.Repository.Interface
{
    public interface ISessionRepository
    {
        public Session GetSessionById(string sessionId);

        public bool UpdateSession(Session session);

        public bool DeleteSession(Session sessionId);
    }
}
