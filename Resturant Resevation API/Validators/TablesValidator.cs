using FluentValidation;
using ResturantDataModel;

namespace Resturant_Resevation_API.Validators
{
    public class TablesValidator : AbstractValidator<Tables>
    {
        public TablesValidator()
        {
            RuleFor(table => table.resturant_id).NotNull().NotEmpty();
            RuleFor(table => table.capacity).NotNull().NotEmpty().InclusiveBetween(0, 5000);

        }
    }
}
