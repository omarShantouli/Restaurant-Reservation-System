using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_Reservations_Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateFindCustomersWithLargePartiesProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    CREATE PROCEDURE FindCustomersWithLargeParties
                                        @PartySizeThreshold INT
                                    AS
                                    BEGIN
                                        SELECT c.*
                                        FROM Customers c
                                        INNER JOIN Reservations r ON c.customer_id = r.customer_id
                                        WHERE r.party_size > @PartySizeThreshold;
                                    END
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS FindCustomersWithLargeParties;");
        }
    }
}
