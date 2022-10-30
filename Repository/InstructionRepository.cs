﻿using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class InstructionRepository
    {
        private readonly DBContext DBContext;
        public InstructionRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }
        public bool DeleteInstruction(string insId)
        {
            if (GetInstructionbyID(insId) == null) return false;
            this.DBContext.Remove(insId);
            this.DBContext.SaveChanges();
            return true;
        }

        public Instruction GetInstructionbyID(string id)
        {
            Instruction instruction = this.DBContext.Instruction.FirstOrDefault(item => item.InstructionId == id);
            if(instruction == null) return null;
            return instruction;
        }

        public Instruction GetInstructionByInsIDandTrainerID(string insId, string trainerId)
        {
            Instruction instruction = this.DBContext.Instruction.FirstOrDefault(item => item.InstructionId == insId);
            return instruction;
        }

        public Instruction GetInstructionbyTrainer(string trainerid)
        {
            Instruction instruction = this.DBContext.Instruction.FirstOrDefault(item => item.TrainerId == trainerid);
            if (instruction == null) return null;
            return instruction;
        }

        public bool UpdateInstruction(Instruction instruction)
        {
            if (GetInstructionbyID(instruction.InstructionId) == null) return false;
            this.DBContext.Update(instruction);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
