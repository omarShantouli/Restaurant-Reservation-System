using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_Reservations_Db.Migrations
{
    /// <inheritdoc />
    public partial class addView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                  CREATE VIEW ReservationView AS
                                  SELECT
	                                  R.reservation_id,
	                                  C.first_name,
	                                  C.last_name,
	                                  Rst.name,
	                                  Rst.address
                                  FROM reservations R
                                  JOIN customers C ON R.customer_id = C.customer_id
                                  JOIN resturants Rst ON R.resturant_id = Rst.resturant_id;
                                ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS ReservationView;");
        }
    }
}
