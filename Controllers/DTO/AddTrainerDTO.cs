using BodyBuildingApp.Models;
using FluentValidation;

namespace BodyBuildingApp.Controllers.DTO
{
    public class AddTrainerDTO
    {
       
        public string Name { get; set; }
        public string Phone { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public Status status { get; set; }
    }

    public class AddTrainerDTOValidator : AbstractValidator<AddTrainerDTO>
    {
        public AddTrainerDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.password).NotEmpty();
            RuleFor(x => x.role).NotEmpty();
            RuleFor(x => x.status).NotEmpty().IsInEnum();
        }
    }
}
