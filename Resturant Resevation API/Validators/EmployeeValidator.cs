using FluentValidation;
using ResturantDataModel;

namespace Resturant_Resevation_API.Validators
{
    public class EmployeeValidator : AbstractValidator<Employees>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.resturant_id).NotNull().NotEmpty();
            RuleFor(employee => employee.first_name).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(employee => employee.last_name).NotNull().NotEmpty().Matches("^[a-z-A-Z ]*$");
            RuleFor(employee => employee.position).NotNull().NotEmpty().Matches("^[a-z-A-Z0-9 ]*$");
        }
    }
}
