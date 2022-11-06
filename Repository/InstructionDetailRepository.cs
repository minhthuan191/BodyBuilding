using BodyBuildingApp.Models;
using BodyBuildingApp.Utils;
using System.Collections.Generic;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class InstructionDetailRepository
    {
        private readonly DBContext DBContext;
        public InstructionDetailRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }

        public List<InstructionDetail> GetAllInstructionDetailByInstructionId(string id)
        {
            return this.DBContext.InstructionDetail.Where<InstructionDetail>(u => u.InstructionId == id).ToList<InstructionDetail>();
        }
        
        public List<InstructionDetail> GetAllInstructionDetailByExerciseId(string id)
        {
            return this.DBContext.InstructionDetail.Where<InstructionDetail>(u => u.ExerciseId == id).ToList<InstructionDetail>();
        }

        public bool CreateInstructionDetail(InstructionDetail instructionDetail)
        {
            this.DBContext.InstructionDetail.Add(instructionDetail);
            this.DBContext.SaveChanges();
            return true;
        }

    }
}
