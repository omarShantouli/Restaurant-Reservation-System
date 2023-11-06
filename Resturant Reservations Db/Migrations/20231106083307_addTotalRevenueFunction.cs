using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_Reservations_Db.Migrations
{
    /// <inheritdoc />
    public partial class addTotalRevenueFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    create function CalculateTotalRevenue(@RestaurantId INT)
                                    returns decimal(18, 2)
                                    as
		                            begin
                                        declare @TotalRevenue decimal(18, 2)
                                        select @TotalRevenue = sum(total_amount)
			                            from Orders o
			                            join Reservations r on o.reservation_id = r.reservation_id
			                            where r.resturant_id = 1;
                                        return @TotalRevenue
                                    end
                                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS CalculateTotalRevenue;");
        }
    }
}
