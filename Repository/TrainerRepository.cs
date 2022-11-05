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
        public Trainer GetTrainerByPhone(string phone)
        {
            Trainer trainer = this.DBContext.Trainer.FirstOrDefault(item => item.Phone == phone );
            if(trainer == null) return null;
            return trainer;
        }

        public bool CreateTrainer(Trainer trainer)
        { 
                this.DBContext.Trainer.Add(trainer);
                this.DBContext.SaveChanges();
                return true;
        }
        public bool UpdateTrainer(Trainer trainer)
        {
            this.DBContext.Update(trainer);
            this.DBContext.SaveChanges();
            return true;
        } 
        public bool DeleteTrainer(Trainer trainer)
        {
            this.DBContext.Trainer.Remove(trainer);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
