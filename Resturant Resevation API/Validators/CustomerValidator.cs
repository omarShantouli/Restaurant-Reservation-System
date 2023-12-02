using FluentValidation;
using ResturantDataModel;

namespace Resturant_Resevation_API
{
    public class CustomerValidator : AbstractValidator<Customers>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.first_name).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(customer => customer.last_name).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(customer => customer.phone_number).NotNull().NotEmpty().Matches("^[0-9 ]*$");
        }
    }
}
