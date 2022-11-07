using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
            if (exercise == null) return null;
            return exercise;
        }

        public Exercise GetExercisebyId(string id)
        {
            Exercise exercise = this.DBContext.Exercise.FirstOrDefault(item => item.ExerciseId == id);
            if (exercise == null) return null;
            return exercise;
        }

        public (List<Exercise>, int) GetAllExercise(int pageIndex, int pageSize)
        {
            List<Exercise> exercises = this.DBContext.Exercise.ToList();
            var pagelist = (List<Exercise>)exercises.Take((pageIndex + 1) * pageSize).Skip(pageIndex * pageSize).ToList();
            return (pagelist, exercises.Count);
        }

        public bool CreateExercise(Exercise exercise)
        {
                this.DBContext.Exercise.Add(exercise);
                return this.DBContext.SaveChanges() > 0;
        }
        public bool UpdateExcercise(Exercise exercise)
        {
            this.DBContext.Update(exercise);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool DeleteExcercise(Exercise exercise)
        { 
            this.DBContext.Exercise.Remove(exercise);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
