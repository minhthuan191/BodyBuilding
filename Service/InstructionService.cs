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

        public bool CreateInstruction(Instruction instruction)
        {
            if (instruction == null)
            {
                return false;
            }
            else
            {
                return insrepo.CreateInstruction(instruction);
            }
        }

        public bool DeleteInstruction(string insId)
        {
            try
            {
                if (insId == null)
                {
                    return false;
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
                if (id == null || insrepo.GetInstructionbyID(id) == null)
                {
                    return null;
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
                if (trainerid == null || insrepo.GetInstructionbyTrainer(trainerid) == null)
                {
                    return null;
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
                    return false;
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
