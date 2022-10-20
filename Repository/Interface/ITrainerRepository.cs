using BodyBuildingApp.Models;

namespace BodyBuildingApp.Repository.Interface
{
    public interface ITrainerRepository
    {
        public Trainer GetTrainerById(string trainerId);

        public bool UpdateTrainer(Trainer trainer);

        public bool DeleteTrainer(Trainer trainerId);
    }
}
