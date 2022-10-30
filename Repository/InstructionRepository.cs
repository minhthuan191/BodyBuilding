using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace BodyBuildingApp.Repository
{
    public class InstructionRepository
    {
        private readonly DBContext DBContext;
        public InstructionRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
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
        public bool CreateInstruction(Instruction instruction)
        {
            this.DBContext.Entry(instruction).State = EntityState.Modified;
            if(GetInstructionbyID(instruction.InstructionId) != null)
            {
                this.DBContext.Instruction.Add(instruction);
                this.DBContext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("error at repository");
            }
        }
        public bool UpdateInstruction(Instruction instruction)
        {
            this.DBContext.Entry(instruction).State = EntityState.Modified;
            if (GetInstructionbyID(instruction.InstructionId) == null) throw new Exception("error at repository");
            this.DBContext.Update(instruction);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool DeleteInstruction(string insId)
        {
            var instruction = GetInstructionbyID(insId);
            if (instruction == null) throw new Exception("error at repository");
            this.DBContext.Instruction.Remove(instruction);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}
