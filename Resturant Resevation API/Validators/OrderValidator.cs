using FluentValidation;
using ResturantDataModel;

namespace Resturant_Resevation_API.Validators
{
    public class OrderValidator : AbstractValidator<Orders>
    {
        public OrderValidator()
        {
            RuleFor(menuItem => menuItem.order_date).NotNull().NotEmpty();
            RuleFor(menuItem => menuItem.total_amount).NotNull().NotEmpty().InclusiveBetween(1, 5000);
            RuleFor(menuItem => menuItem.reservation_id).NotNull().NotEmpty();
            RuleFor(menuItem => menuItem.employee_id).NotNull().NotEmpty();
        }
    }
}
