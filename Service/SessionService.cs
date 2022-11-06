using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;

namespace BodyBuildingApp.Service
{
    public class SessionService : ISessionService
    {
        private readonly SessionRepository sessrepo;
        public SessionService(SessionRepository sessrepo)
        {
            this.sessrepo = sessrepo;
        }

        public bool CreateSession(Session session)
        {
            if (session == null)
            {
                return false;
            }
            else
            {
                return sessrepo.CreateSession(session);
            }
        }

        public bool DeleteSession(string sessionId)
        {
            try
            {
                if (sessionId == null)
                {
                    return false ;
                }
                else
                {
                    return sessrepo.DeleteSession(sessionId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Session GetSessionById(string sessionId)
        {
            try
            {
                if (sessionId == null || sessrepo.GetSessionById(sessionId) == null)
                {
                    return null;
                }
                else
                {
                    return sessrepo.GetSessionById(sessionId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateSession(Session session)
        {
            try
            {
                if (session == null)
                {
                    return false;
                }
                else
                {
                    return sessrepo.UpdateSession(session);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
