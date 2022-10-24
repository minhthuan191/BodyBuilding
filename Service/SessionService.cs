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

        public bool DeleteSession(Session sessionId)
        {
            try
            {
                if (sessionId == null)
                {
                    throw new Exception("Error at get DeleteSession");
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
                if (sessionId == null)
                {
                    throw new Exception("Error at get GetSessionById");
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
                    throw new Exception("Error at get UpdateSession");
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
