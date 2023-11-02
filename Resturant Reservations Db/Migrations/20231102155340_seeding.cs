using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_Reservations_Db.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 1,
                column: "order_date",
                value: new DateTime(2023, 11, 2, 17, 53, 40, 37, DateTimeKind.Local).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 2,
                column: "order_date",
                value: new DateTime(2023, 11, 2, 17, 53, 40, 37, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 3,
                column: "order_date",
                value: new DateTime(2023, 11, 2, 17, 53, 40, 37, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 4,
                column: "order_date",
                value: new DateTime(2023, 11, 2, 17, 53, 40, 37, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 5,
                column: "order_date",
                value: new DateTime(2023, 11, 2, 17, 53, 40, 37, DateTimeKind.Local).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 1,
                column: "reservation_date",
                value: new DateTime(2023, 11, 2, 17, 53, 40, 37, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 2,
                column: "reservation_date",
                value: new DateTime(2023, 11, 2, 17, 53, 40, 37, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 3,
                column: "reservation_date",
                value: new DateTime(2023, 11, 2, 17, 53, 40, 37, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 4,
                column: "reservation_date",
                value: new DateTime(2023, 11, 2, 17, 53, 40, 37, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 5,
                column: "reservation_date",
                value: new DateTime(2023, 11, 2, 17, 53, 40, 37, DateTimeKind.Local).AddTicks(5922));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 1,
                column: "order_date",
                value: new DateTime(2023, 11, 2, 17, 52, 21, 723, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 2,
                column: "order_date",
                value: new DateTime(2023, 11, 2, 17, 52, 21, 723, DateTimeKind.Local).AddTicks(1021));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 3,
                column: "order_date",
                value: new DateTime(2023, 11, 2, 17, 52, 21, 723, DateTimeKind.Local).AddTicks(1023));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 4,
                column: "order_date",
                value: new DateTime(2023, 11, 2, 17, 52, 21, 723, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 5,
                column: "order_date",
                value: new DateTime(2023, 11, 2, 17, 52, 21, 723, DateTimeKind.Local).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 1,
                column: "reservation_date",
                value: new DateTime(2023, 11, 2, 17, 52, 21, 723, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 2,
                column: "reservation_date",
                value: new DateTime(2023, 11, 2, 17, 52, 21, 723, DateTimeKind.Local).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 3,
                column: "reservation_date",
                value: new DateTime(2023, 11, 2, 17, 52, 21, 723, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 4,
                column: "reservation_date",
                value: new DateTime(2023, 11, 2, 17, 52, 21, 723, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 5,
                column: "reservation_date",
                value: new DateTime(2023, 11, 2, 17, 52, 21, 723, DateTimeKind.Local).AddTicks(1080));
        }
    }
}
