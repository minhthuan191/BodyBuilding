using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface IExerciseSessionService
    {
        public List<string> convertStringToList(string input);
        public string convertListToString(List<string> list);
        public List<Exercise> GetListExercise(List<string> list);
    }
}
