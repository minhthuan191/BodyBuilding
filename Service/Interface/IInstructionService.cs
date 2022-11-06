using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface IInstructionService
    {
        public Instruction GetInstructionbyID(string id);

        public List<Instruction> GetInstructionbyTrainer(string trainerid);

        public bool CreateInstruction(Instruction instruction);

        public bool UpdateInstruction(Instruction instruction);

        public bool DeleteInstruction(string insId);
    }
}
