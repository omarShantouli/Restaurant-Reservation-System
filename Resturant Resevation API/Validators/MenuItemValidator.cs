using FluentValidation;
using ResturantDataModel;

namespace Resturant_Resevation_API.Validators
{
    public class MenuItemValidator : AbstractValidator<MenuItems>
    {
        public MenuItemValidator()
        {
            RuleFor(menuItem => menuItem.resturant_id).NotNull().NotEmpty();
            RuleFor(menuItem => menuItem.name).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(menuItem => menuItem.description).NotNull().NotEmpty().Matches("^[a-z-A-Z ]*$");
            RuleFor(menuItem => menuItem.price).NotNull().NotEmpty().InclusiveBetween(1, 300);
        }
    }
}
