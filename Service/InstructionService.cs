using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;

namespace BodyBuildingApp.Service
{
    public class InstructionService : IInstructionService
    {
        private readonly InstructionRepository insrepo;

        public InstructionService(InstructionRepository insrepo)
        {
            this.insrepo = insrepo;
        }

        public bool DeleteInstruction(Instruction insId)
        {
            try
            {
                if (insId == null)
                {
                    throw new Exception("Error at get DeleteInstruction");
                }
                else
                {
                    return insrepo.DeleteInstruction(insId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Instruction GetInstructionbyID(string id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Error at get DeleteInstruction");
                }
                else
                {
                    return insrepo.GetInstructionbyID(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Instruction GetInstructionByInsIDandTrainerID(string insId, string trainerId)
        {
            throw new System.NotImplementedException();
        }

        public Instruction GetInstructionbyTrainer(string trainerid)
        {
            try
            {
                if (trainerid == null)
                {
                    throw new Exception("Error at get GetInstructionbyTrainer");
                }
                else
                {
                    return insrepo.GetInstructionbyTrainer(trainerid);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateInstruction(Instruction instruction)
        {
            try
            {
                if (instruction == null)
                {
                    throw new Exception("Error at get UpdateInstruction");
                }
                else
                {
                    return insrepo.UpdateInstruction(instruction);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
