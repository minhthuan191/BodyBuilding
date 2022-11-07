using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Service
{
    public class ExerciseService : IExerciseService
    {
        private readonly ExerciseRepository ecrepo;

        public ExerciseService(ExerciseRepository ecrepo)
        {
            this.ecrepo = ecrepo;
        }

        public bool CreateExcercise(Exercise exercise)
        {
                return ecrepo.CreateExercise(exercise);
        }

        public bool DeleteExcercise(Exercise exercise)
        {     
                    return ecrepo.DeleteExcercise(exercise);
        }

        public Exercise GetExercisebyBodyPart(string bodyPart)
        {
                    return ecrepo.GetExercisebyBodyPart(bodyPart);
        }

        public Exercise GetExercisebyId(string id)
        {
                    return ecrepo.GetExercisebyId(id);
        }

        public Exercise GetExercisebyName(string name)
        {
            return ecrepo.GetExercisebyName(name);
        }
        public List<Exercise>GetListExercise()
        {
            return ecrepo.GetAllExercise();
        }

        public bool UpdateExcercise(Exercise exercise)
        {
                    return ecrepo.UpdateExcercise(exercise);

        }

    }
}
