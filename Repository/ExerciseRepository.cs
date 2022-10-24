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
        public bool DeleteExcercise(Exercise id)
        {
            this.DBContext.Remove(id);
            this.DBContext.SaveChanges();
            return true;
        }

        public Exercise GetExercisebyBodyPart(string bodyPart)
        {
            Exercise exercise = this.DBContext.Exercise.FirstOrDefault(item => item.BodyPart == bodyPart);
            return exercise;
        }

        public Exercise GetExercisebyId(string id)
        {
            Exercise exercise = this.DBContext.Exercise.FirstOrDefault(item => item.ExerciseId == id);
            return exercise;
        }

        public bool UpdateExcercise(Exercise exercise)
        {
            this.DBContext.Update(exercise);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
