using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Utils;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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


        public List<Instruction> GetInstructionbyTrainer(string trainerid)
        {
            List<Instruction> instruction = this.DBContext.Instruction.Where(item => item.TrainerId == trainerid).ToList();
            if (instruction == null) return null;
            return instruction;
        }
        public bool CreateInstruction(Instruction instruction)
        {
                this.DBContext.Instruction.Add(instruction);
                this.DBContext.SaveChanges();
                return true;
        }
        public bool UpdateInstruction(Instruction instruction)
        {
           
            this.DBContext.Update(instruction);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool DeleteInstruction(Instruction instruction)
        {
            this.DBContext.Instruction.Remove(instruction);
            this.DBContext.SaveChanges();
            return true;
        }

        public (List<Instruction>, int) GetInstructions(string userId, int pageIndex, int pageSize)
        {
            List<Instruction> instructions = this.DBContext.Instruction.Where(o => o.CustomerId == userId).ToList();
            var result = instructions.Take((pageIndex + 1) * pageSize).Skip(pageIndex * pageSize).ToList();
            return (result, instructions.Count);
        }

        public List<InstructionDetail> GetInstructionDetail(string instructionId)
        {
            List<InstructionDetail> instructionDetail = this.DBContext.InstructionDetail.Where(x => x.InstructionId == instructionId).ToList();
            foreach (var exercise in instructionDetail)
            {
                this.DBContext.Exercise.Where(item => item.ExerciseId == exercise.ExerciseId).Load();
            }
            var pagelist = (List<InstructionDetail>)instructionDetail.ToList();
            return pagelist;
        }

        public List<InstructionDetail> GetAllInstructions()
        {
            List<InstructionDetail> orders = this.DBContext.InstructionDetail.ToList();
            var result = orders.ToList();
            return result;
        }
    }
}
