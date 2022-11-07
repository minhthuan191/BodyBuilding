using BodyBuildingApp.Models;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace BodyBuildingApp.Controllers.DTO
{
    public class AddScheduleDTO
    {
        public string scheduleId { get; set; }
        public string StartDate { set; get; }

        public string EndDate { set; get; }

        public Status Status { set; get; }

    }
    public class AddScheduleDTOValidator : AbstractValidator<AddScheduleDTO>
    {
        public AddScheduleDTOValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();

        }
    }
    public class UpdateScheduleDTO
    {
        public Status Status { set; get; }
    }
    public class UpdateScheduleDTOValidator : AbstractValidator<UpdateScheduleDTO>
    {
        public UpdateScheduleDTOValidator()
        {
            RuleFor(x => x.Status).NotEmpty();

        }
    }
}
