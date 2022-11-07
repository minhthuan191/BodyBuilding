using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface IExerciseService
    {
        public Exercise GetExercisebyId(string id);
        public Exercise GetExercisebyName(string name);
        public List<Exercise> GetListExercise();

        public Exercise GetExercisebyBodyPart(string bodyPart);

        public bool CreateExcercise(Exercise exercise);

        public bool UpdateExcercise(Exercise exercise);

        public bool DeleteExcercise(Exercise exercise);
    }
}
