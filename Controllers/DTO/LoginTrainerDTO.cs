using BodyBuildingApp.Utils.Validator;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BodyBuildingApp.Controllers.DTO
{
    public class LoginTrainerDTO
    {
        public string Phone { set; get; }
        public string Password { set; get; }

    }
    public class LoginTrainerDTOValidator : AbstractValidator<LoginTrainerDTO>
    {
        public LoginTrainerDTOValidator()
        {
            RuleFor(x => x.Phone).NotEmpty().NotNull().Matches(new Regex(@"^(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b"));
            RuleFor(x => x.Password).NotEmpty().Length(CustomerValidator.PASSWORD_MIN, CustomerValidator.PASSWORD_MAX);

        }
    }
}
