using FluentValidation;
using ResturantDataModel;

namespace Resturant_Resevation_API.Validators
{
    public class OrderItemValidator : AbstractValidator<OrderItems>
    {
        public OrderItemValidator()
        {
            RuleFor(orderItem => orderItem.quantity).NotNull().NotEmpty().InclusiveBetween(1, 1000);
            RuleFor(orderItem => orderItem.order_id).NotNull().NotEmpty();
            RuleFor(orderItem => orderItem.item_id).NotNull().NotEmpty();
        }
    }
}
