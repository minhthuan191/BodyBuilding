using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace BodyBuildingApp.Repository
{
    public class ExerciseRepository 
    {
        private readonly DBContext DBContext;
        public ExerciseRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
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
        public bool CreateExercise(Exercise exercise)
        {
            this.DBContext.Entry(exercise).State = EntityState.Modified;
            if(GetExercisebyId(exercise.ExerciseId) != null)
            {
                this.DBContext.Exercise.Add(exercise);
                this.DBContext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("error at repository");
            }
        }
        public bool UpdateExcercise(Exercise exercise)
        {
            this.DBContext.Entry(exercise).State = EntityState.Modified;
            if (GetExercisebyId(exercise.ExerciseId) == null) throw new Exception("error at repository");
            this.DBContext.Update(exercise);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool DeleteExcercise(string id)
        {
            var exercise = GetExercisebyId(id);
            if (exercise == null) throw new Exception("error at repository");
            this.DBContext.Exercise.Remove(exercise);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
