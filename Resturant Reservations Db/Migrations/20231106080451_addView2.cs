using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_Reservations_Db.Migrations
{
    /// <inheritdoc />
    public partial class addView2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                   CREATE VIEW EmployeeRestaurantView AS
                                   select E.employee_id, E.first_name, E.last_name, E.position,
	                               R.resturant_id, R.address, R.name, R.opening_hours, R.phone_number
                                   from Employees E
                                   join Resturants R on R.resturant_id = E.resturant_id
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS EmployeeRestaurantView;");
        }
    }
}
