using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class ExerciseRepository 
    {
        private readonly DBContext DBContext;
        public ExerciseRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }
        public bool DeleteExcercise(string id)
        {
            if(GetExercisebyId(id) == null) return false;
            this.DBContext.Remove(id);
            this.DBContext.SaveChanges();
            return true;
        }

        public Exercise GetExercisebyBodyPart(string bodyPart)
        {
            Exercise exercise = this.DBContext.Exercise.FirstOrDefault(item => item.BodyPart == bodyPart);
            if (GetExercisebyBodyPart == null) return null;
            return exercise;
        }

        public Exercise GetExercisebyId(string id)
        {
            Exercise exercise = this.DBContext.Exercise.FirstOrDefault(item => item.ExerciseId == id);
            if (GetExercisebyId == null) return null;
            return exercise;
        }

        public bool UpdateExcercise(Exercise exercise)
        {
            if (GetExercisebyId(exercise.ExerciseId) == null) return false;
            this.DBContext.Update(exercise);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
