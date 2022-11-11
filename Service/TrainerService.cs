using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Service
{
    public class TrainerService : ITrainerService

    {
        private readonly TrainerRepository tnrepo;


        public List<Trainer> GetAllTrainer()
        {
            return tnrepo.GetListTrainer();
        }
        public TrainerService(TrainerRepository tnrepo)
        {
            this.tnrepo = tnrepo;
        }

        public bool CreateTrainer(Trainer trainer)
        {
            return tnrepo.CreateTrainer(trainer);

        }

        public bool DeleteTrainer(string id)
        {
            return tnrepo.DeleteTrainer(id);
        }

        public Trainer GetTrainerById(string trainerId)
        {
            return tnrepo.GetTrainerById(trainerId);
        }

        public bool UpdateTrainer(Trainer trainer)
        {
            return tnrepo.UpdateTrainer(trainer);

        }

        public Trainer GetTrainerByPhone(string phone)
        {
            return tnrepo.GetTrainerByPhone(phone);
        }
    }
}
