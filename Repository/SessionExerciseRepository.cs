using BodyBuildingApp.Utils;
using BodyBuildingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BodyBuildingApp.Service;
using System;

namespace BodyBuildingApp.Repository
{
    public class SessionExerciseRepository
    {
        private readonly DBContext dBContext;

        public SessionExerciseRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public SessionExercise GetSessionExerciseID(string id)
        {
            SessionExercise se = this.dBContext.SessionExercise.FirstOrDefault(item => item.SessionExerciseId == id);
            if (se == null) return null;
            else return se;
        }
        public bool UpdateSessionExcersise(SessionExercise sessionExercise)
        {
            this.dBContext.Entry(sessionExercise).State = EntityState.Modified;
            if(sessionExercise == null)
            {
                return false;
            }
            else
            {
                this.dBContext.SessionExercise.Add(sessionExercise);
                this.dBContext.SaveChanges();
                return true;
            }
        }
        public bool DeleteSessionExercise(string id)
        {
            var se = GetSessionExerciseID(id);
            if (se == null)
            {
                return false;
            }
            else
            {
                this.dBContext.SessionExercise.Remove(se);
                this.dBContext.SaveChanges();
                return true;
            }
        }
        public bool CreateSessionExercise(SessionExercise sessionExercise)
        {
            if(sessionExercise == null )
            { 
                return false;
            }
            else
            {
                this.dBContext.SessionExercise.Add(sessionExercise);
                this.dBContext.SaveChanges();
                return true;
            }
        }

        internal bool CreateSessionExercise(SessionExerciseService sessionExercise)
        {
            throw new NotImplementedException();
        }
    }
}
