using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace BodyBuildingApp.Repository
{
    public class TrainerRepository
    {
        private readonly DBContext DBContext;
        public TrainerRepository(DBContext dBContext)
        {
            DBContext = dBContext;
        }

        public Trainer GetTrainerById(string trainerId)
        {
            Trainer trainer = this.DBContext.Trainer.FirstOrDefault(item => item.TrainerId == trainerId);
            if(trainer == null) return null;
            return trainer;
        }

        public bool CreateTrainer(Trainer trainer)
        {
            this.DBContext.Entry(trainer).State = EntityState.Modified;
            if(GetTrainerById(trainer.TrainerId) != null)
            {
                this.DBContext.Trainer.Add(trainer);
                this.DBContext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("error at repository");
            }
        }
        public bool UpdateTrainer(Trainer trainer)
        {
            this.DBContext.Entry(trainer).State = EntityState.Modified;
            if (GetTrainerById(trainer.TrainerId) == null) throw new Exception("error at repository");
            this.DBContext.Update(trainer);
            this.DBContext.SaveChanges();
            return true;
        } 
        public bool DeleteTrainer(string trainerId)
        {
            var trainer = GetTrainerById(trainerId);
            if (trainer == null) throw new Exception("error at repository");
            this.DBContext.Trainer.Remove(trainer);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
