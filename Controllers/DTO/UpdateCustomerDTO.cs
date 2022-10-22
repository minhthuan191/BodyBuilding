using BodyBuildingApp.Utils.Validator;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BodyBuildingApp.Controllers.DTO
{
    public class UpdateCustomerDTO
    {
        public string UserId { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public string Status { set; get; }
    }

    public class UpdateCustomerDTOValidator : AbstractValidator<UpdateCustomerDTO>
    {
        public UpdateCustomerDTOValidator()
        {

            RuleFor(x => x.Name).NotEmpty().Length(CustomerValidator.NAME_MIN, CustomerValidator.NAME_MAX);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().NotNull().Matches(new Regex(@"^(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b"));
            RuleFor(x => x.Address).NotEmpty().Length(CustomerValidator.ADDRESS_MIN, CustomerValidator.ADDRESS_MAX);
        }
    }
}
