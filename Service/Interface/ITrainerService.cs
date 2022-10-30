﻿using BodyBuildingApp.Models;

namespace BodyBuildingApp.Service.Interface
{
    public interface ITrainerService
    {
        public Trainer GetTrainerById(string trainerId);

        public bool CreateTrainer(Trainer trainer);

        public bool UpdateTrainer(Trainer trainer);

        public bool DeleteTrainer(string trainerId);
    }
}
