using BodyBuildingApp.Models;

namespace BodyBuildingApp.Service.Interface
{
    public interface IExerciseService
    {
        public Exercise GetExercisebyId(string id);

        public Exercise GetExercisebyBodyPart(string bodyPart);

        public bool CreateExcercise(Exercise exercise);

        public bool UpdateExcercise(Exercise exercise);

        public bool DeleteExcercise(Exercise exercise);
    }
}
