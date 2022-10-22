using BodyBuildingApp.Models;
using BodyBuildingApp.Repository.Interface;
using BodyBuildingApp.Utils;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly DBContext DBContext;
        public bool DeleteTrainer(Trainer trainerId)
        {
            this.DBContext.Remove(trainerId);
            this.DBContext.SaveChanges();
            return true;
        }

        public Trainer GetTrainerById(string trainerId)
        {
            Trainer trainer = this.DBContext.Trainer.FirstOrDefault(item => item.TrainerId == trainerId);
            return trainer;
        }

        public bool UpdateTrainer(Trainer trainer)
        {
            this.DBContext.Update(trainer);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
