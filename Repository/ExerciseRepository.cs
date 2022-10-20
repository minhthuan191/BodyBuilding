using BodyBuildingApp.Models;
using BodyBuildingApp.Repository.Interface;
using BodyBuildingApp.Utils;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly DBContext DBContext;
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
