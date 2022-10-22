using BodyBuildingApp.Models;

namespace BodyBuildingApp.Repository.Interface
{
    public interface IInstructionRepository
    {
        public Instruction GetInstructionbyID(string id);

        public Instruction GetInstructionbyTrainer(string trainerid);

        public Instruction GetInstructionByInsIDandTrainerID(string insId, string trainerId);

        public bool UpdateInstruction(Instruction instruction);

        public bool DeleteInstruction(Instruction insId);
    }
}
