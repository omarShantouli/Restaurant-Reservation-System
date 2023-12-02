using FluentValidation;
using ResturantDataModel;

namespace Resturant_Resevation_API.Validators
{
    public class ReservationValidator : AbstractValidator<Reservations>
    {
        public ReservationValidator()
        {
            RuleFor(menuItem => menuItem.customer_id).NotNull().NotEmpty();
            RuleFor(menuItem => menuItem.resturant_id).NotNull().NotEmpty();
            RuleFor(menuItem => menuItem.table_id).NotNull().NotEmpty();
            RuleFor(menuItem => menuItem.party_size).NotNull().NotEmpty().InclusiveBetween(1, 5000);
        }
    }
}
