using BodyBuildingApp.Models;
using BodyBuildingApp.Repository.Interface;
using BodyBuildingApp.Utils;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly DBContext DBContext;
        public bool DeleteSession(Session sessionId)
        {
            this.DBContext.Remove(sessionId);
            this.DBContext.SaveChanges();
            return true;
        }

        public Session GetSessionById(string sessionId)
        {
            Session session = this.DBContext.Session.FirstOrDefault(item => item.SessionId == sessionId);
            return session;
        }

        public bool UpdateSession(Session session)
        {
            this.DBContext.Update(session);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
