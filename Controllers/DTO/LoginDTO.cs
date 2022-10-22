using BodyBuildingApp.Utils.Validator;
using FluentValidation;


namespace BodyBuildingApp.Controllers.DTO
{
    public class LoginDTO
    {
        public string Email { set; get; }
        public string Password { set; get; }

    }
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().Length(CustomerValidator.PASSWORD_MIN, CustomerValidator.PASSWORD_MAX);

        }
    }
}
