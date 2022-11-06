using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Models;
using System.Net;

namespace BodyBuildingApp.Service
{
    public class SessionExerciseService : ISessionExerciseService
    {
        private readonly SessionExerciseRepository serepo;

        public SessionExerciseService(SessionExerciseRepository serepo)
        {
            this.serepo = serepo;
        }

        public bool CreateSessionExercise(SessionExercise sessionExercise)
        {
         
            if (sessionExercise == null)
            {
                return false;
            }
            else 
            {
                serepo.CreateSessionExercise(sessionExercise);
                return true; 
            }
        }

        public bool DeleteSessionExercise(string seid)
        {
            if(seid == null)
            {
                return false;
            }
            else
            {
                serepo.DeleteSessionExercise(seid);
                return true;
            }
        }

        public SessionExercise GetSessionExerciseID(string seid)
        {
            if(seid == null)
            {
                return null;
            }
            else
            {
              return serepo.GetSessionExerciseID(seid);
            }
        }

        public bool UpdateSessionExercise(SessionExercise sessionExercise)
        {
            if(sessionExercise == null)
            {
                return false;
            }
            else
            {
                 serepo.UpdateSessionExcersise(sessionExercise);
                return true;
            }
        }
    }
}
