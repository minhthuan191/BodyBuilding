using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Service
{
    public class InstructionService : IInstructionService
    {
        private readonly InstructionRepository insrepo;

        public InstructionService(InstructionRepository insrepo)
        {
            this.insrepo = insrepo;
        }

        public bool CreateInstruction(Instruction instruction)
        {
  
                return insrepo.CreateInstruction(instruction);
            
        }

        public bool DeleteInstruction(Instruction instruction)
        {
          
                    return insrepo.DeleteInstruction(instruction);
        }

        public bool DeleteInstruction(string insId)
        {
            throw new NotImplementedException();
        }

        public Instruction GetInstructionbyID(string id)
        {
           
                
                    return insrepo.GetInstructionbyID(id);

        }


        public List<Instruction> GetInstructionbyTrainer(string trainerid)
        {

              return insrepo.GetInstructionbyTrainer(trainerid);
        }

        public bool UpdateInstruction(Instruction instruction)
        {
                    return insrepo.UpdateInstruction(instruction);
        }
    }
}
