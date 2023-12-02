using FluentValidation;
using ResturantDataModel;

namespace Resturant_Resevation_API.Validators
{
    public class ResturantValidator : AbstractValidator<Resturants>
    {
        public ResturantValidator()
        {
            RuleFor(resturant => resturant.name).NotNull().NotEmpty().Matches("^[a-z-A-Z0-9 ]*$");
            RuleFor(resturant => resturant.address).NotNull().NotEmpty().Matches("^[a-z-A-Z0-9 ]*$");
            RuleFor(resturant => resturant.phone_number).NotNull().NotEmpty().Matches("^[0-9 ]*$");
            RuleFor(resturant => resturant.opening_hours).NotNull().NotEmpty();
        }
    }
}
