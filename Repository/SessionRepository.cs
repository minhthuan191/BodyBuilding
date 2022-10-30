using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class SessionRepository
    {
        private readonly DBContext DBContext;
        public SessionRepository(DBContext dBContext)
        {
            DBContext = dBContext;
        }

        public bool DeleteSession(string sessionId)
        {
            if (GetSessionById(sessionId) == null) return false;
            this.DBContext.Remove(sessionId);
            this.DBContext.SaveChanges();
            return true;
        }

        public Session GetSessionById(string sessionId)
        {
            Session session = this.DBContext.Session.FirstOrDefault(item => item.SessionId == sessionId);
            if(session == null) return null;
            return session;
        }

        public bool UpdateSession(Session session)
        {
            if (GetSessionById(session.SessionId) == null) return false;
            this.DBContext.Update(session);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
