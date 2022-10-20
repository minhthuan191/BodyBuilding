using BodyBuildingApp.Models;

namespace BodyBuildingApp.Repository.Interface
{
    public interface IExerciseRepository
    {
        public Exercise GetExercisebyId(string id);

        public Exercise GetExercisebyBodyPart(string bodyPart);

        public bool UpdateExcercise(Exercise exercise);

        public bool DeleteExcercise(Exercise id);
    }
}
