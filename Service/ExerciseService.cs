using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;

namespace BodyBuildingApp.Service
{
    public class ExerciseService : IExerciseService
    {
        private readonly ExerciseRepository ecrepo;

        public ExerciseService(ExerciseRepository ecrepo)
        {
            this.ecrepo = ecrepo;
        }

        public bool DeleteExcercise(string id)
        {
            try
            {
                if (id == null || ecrepo.GetExercisebyId(id) ==null)
                {
                    return false;
                }
                else
                {
                    return ecrepo.DeleteExcercise(id);
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Exercise GetExercisebyBodyPart(string bodyPart)
        {
            try
            {
                if (bodyPart == null || ecrepo.GetExercisebyBodyPart(bodyPart) == null)
                {
                    return null;
                }
                else
                {
                    return ecrepo.GetExercisebyBodyPart(bodyPart);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Exercise GetExercisebyId(string id)
        {
            try
            {
                if (id == null|| ecrepo.GetExercisebyId(id) == null)
                {
                    return null;
                }
                else
                {
                    return ecrepo.GetExercisebyId(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateExcercise(Exercise exercise)
        {
            try
            {
                if (exercise == null || ecrepo.GetExercisebyId(exercise.ExerciseId) == null)
                {
                    return false;
                }
                else
                {
                    return ecrepo.UpdateExcercise(exercise);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
