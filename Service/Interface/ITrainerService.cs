using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface ITrainerService
    {
        public List<Trainer> GetAllTrainer();
        public Trainer GetTrainerById(string trainerId);
        public Trainer GetTrainerByPhone(string phone);

        public bool CreateTrainer(Trainer trainer);

        public bool UpdateTrainer(Trainer trainer);

        public bool DeleteTrainer(string id);
    }
}
