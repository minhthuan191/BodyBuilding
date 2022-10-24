using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;

namespace BodyBuildingApp.Service
{
    public class TrainerService : ITrainerService

    {
        private readonly TrainerRepository tnrepo;

        public TrainerService(TrainerRepository tnrepo)
        {
            this.tnrepo = tnrepo;
        }
        public bool DeleteTrainer(Trainer trainerId)
        {
            try
            {
                if (trainerId == null)
                {
                    throw new Exception("Error at get DeleteTrainer");
                }
                else
                {
                    return tnrepo.DeleteTrainer(trainerId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Trainer GetTrainerById(string trainerId)
        {
            try
            {
                if (trainerId == null)
                {
                    throw new Exception("Error at get GetTrainerById");
                }
                else
                {
                    return tnrepo.GetTrainerById(trainerId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateTrainer(Trainer trainer)
        {
            try
            {
                if (trainer == null)
                {
                    throw new Exception("Error at get UpdateTrainer");
                }
                else
                {
                    return tnrepo.UpdateTrainer(trainer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
