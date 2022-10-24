using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class TrainerRepository
    {
        private readonly DBContext DBContext;
        public TrainerRepository(DBContext dBContext)
        {
            DBContext = dBContext;
        }

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
