using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using System.Collections.Generic;

namespace BodyBuildingApp.Service
{
    public class ExerciseSessionService : IExerciseSessionService
    {
        private readonly IExerciseService ExerciseService;
        public ExerciseSessionService(IExerciseService exerciseService)
        {
            this.ExerciseService = exerciseService;
        }
        public List<string> convertStringToList(string input)
        {

            List<string> list = new List<string>();

            if (input != null && input.Trim().Length != 0)
            {
                var arr = input.Split(",");
                foreach (var item in arr)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public string convertListToString(List<string> list)
        {
            string exerciseSession = "";
            foreach (var exerciseId in list)
            { 
                if (exerciseSession == "")
                {
                    exerciseSession = exerciseId;
                }
                else
                {
                    exerciseSession += "," + exerciseId;
                }

            }
            return exerciseSession;
        }

        public List<Exercise> GetListExercise(List<string> list)
        {
            List<Exercise> exercises = new List<Exercise>();
            foreach(var item in list)
            {
                exercises.Add(this.ExerciseService.GetExercisebyId(item));
            }
            return exercises;
        }

    }
}
