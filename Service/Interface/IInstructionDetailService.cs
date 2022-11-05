using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface IInstructionDetailService
    {
        public List<InstructionDetail> GetAllInstructionDetailByInstructionId(string id);
        public List<InstructionDetail> GetAllInstructionDetailByExerciseId(string id);

    }
}
