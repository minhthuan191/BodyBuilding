using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Repository
{
    public class TrainerRepository
    {
        private readonly DBContext DBContext;
        public TrainerRepository(DBContext dBContext)
        {
            DBContext = dBContext;
        }

        public List<Trainer> GetListTrainer()
        {
            List<Trainer> trainer = this.DBContext.Set<Trainer>().ToList<Trainer>();
            return trainer;

        }
        public Trainer GetTrainerById(string trainerId)
        {
            Trainer trainer = this.DBContext.Trainer.FirstOrDefault(item => item.TrainerId == trainerId);
            if (trainer == null) return null;
            return trainer;
        }
        public Trainer GetTrainerByPhone(string phone)
        {
            Trainer trainer = this.DBContext.Trainer.FirstOrDefault(item => item.Phone == phone);
            if (trainer == null) return null;
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
            this.DBContext.Entry(trainer).State = EntityState.Modified;
            if (GetTrainerById(trainer.TrainerId) != null)
            {
                return false;
            }
            this.DBContext.Trainer.Update(trainer);
            this.DBContext.SaveChanges();
            return true;
        }
        public bool DeleteTrainer(string id)
        {
            var trainer = GetTrainerById(id);
            if (trainer == null) return false;
            this.DBContext.Trainer.Remove(trainer);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
