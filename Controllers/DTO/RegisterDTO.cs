using BodyBuildingApp.Utils.Validator;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BodyBuildingApp.Controllers.DTO
{
    public class RegisterDTO
    {
        public string Name { set; get; }
        public string Gender { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }

        public string Role { set; get; }
        public string Address { set; get; }
    }

    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().Length(CustomerValidator.PASSWORD_MIN, CustomerValidator.PASSWORD_MAX);
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password);
            RuleFor(x => x.Name).NotEmpty().Length(CustomerValidator.NAME_MIN, CustomerValidator.NAME_MAX);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().NotNull().Matches(new Regex(@"^(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b"));
            RuleFor(x => x.Address).NotEmpty().Length(CustomerValidator.ADDRESS_MIN, CustomerValidator.ADDRESS_MAX);
        }
    }
}
