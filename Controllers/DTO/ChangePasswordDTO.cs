using BodyBuildingApp.Utils.Validator;
using FluentValidation;

namespace BodyBuildingApp.Controllers.DTO
{
    public class ChangePasswordDTO
    {
        public string Password { set; get; }
        public string NewPassword { set; get; }
        public string ConfirmNewPassword { set; get; }

    }
    public class ChangePasswordDTOValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordDTOValidator()
        {
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.NewPassword).NotEmpty().Length(CustomerValidator.PASSWORD_MIN, CustomerValidator.PASSWORD_MAX);
            RuleFor(x => x.ConfirmNewPassword).NotEmpty().Length(CustomerValidator.PASSWORD_MIN, CustomerValidator.PASSWORD_MAX);


        }
    }
}
