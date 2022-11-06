using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingApp.Repository
{
    public class SessionRepository
    {
        private readonly DBContext DBContext;
        public SessionRepository(DBContext dBContext)
        {
            DBContext = dBContext;
        }
        public Session GetSessionById(string sessionId)
        {
            Session session = this.DBContext.Session.FirstOrDefault(item => item.SessionId == sessionId);
            if(session == null) return null;
            return session;
        }
        public bool CreateSession(Session session)
        {
            this.DBContext.Entry(session).State = EntityState.Modified;
            if(GetSessionById(session.SessionId) != null)
            {
                this.DBContext.Session.Add(session);
                this.DBContext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("error at repository");
            }
        }
        public bool UpdateSession(Session session)
        {
            this.DBContext.Entry(session).State = EntityState.Modified;
            if (GetSessionById(session.SessionId) == null) return false ;
            this.DBContext.Update(session);
            this.DBContext.SaveChanges();
            return true;
        } 
        public bool DeleteSession(string sessionId)
        {
            var session = GetSessionById(sessionId);
            if (session == null) throw new Exception("error at repository");
            this.DBContext.Session.Remove(session);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
