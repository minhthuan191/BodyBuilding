using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System.Collections.Generic;

namespace BodyBuildingApp.Service
{
    public class InstructionDetailService : IInstructionDetailService
    {
        private readonly InstructionDetailRepository InstructionDetailRepository;
        public InstructionDetailService (InstructionDetailRepository instructionDetailRepository)
        {
            this.InstructionDetailRepository = instructionDetailRepository;
        }

        public bool CreateInstructionDetail(InstructionDetail instructionDetail)
        {
            return InstructionDetailRepository.CreateInstructionDetail(instructionDetail);
        }

        public List<InstructionDetail> GetAllInstructionDetailByExerciseId(string id)
        {
            return InstructionDetailRepository.GetAllInstructionDetailByExerciseId(id);
        }

        public List<InstructionDetail> GetAllInstructionDetailByInstructionId(string id)
        {
            return InstructionDetailRepository.GetAllInstructionDetailByInstructionId(id);
        }
    }
}
