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

        public bool CreateTrainer(Trainer trainer)
        {
            if (trainer == null)
            {
                return false;
            }
            else
            {
                return tnrepo.CreateTrainer(trainer);
            }
        }

        public bool DeleteTrainer(string trainerId)
        {
            try
            {
                if (trainerId == null)
                {
                   return false;
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
                if (trainerId == null || tnrepo.GetTrainerById(trainerId) == null)
                {
                    return null;
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
                    return false;
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
