using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MASFlightBooking.Domain.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MASFlights",
                columns: new[] { "Id", "Airline", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Departure", "Destination", "FlightCategories", "IsDeleted", "MobileNumber", "ModifiedBy", "ModifiedOn", "Number_of_passanger", "TicketName", "TravelerAge", "TripType", "UpdatedOn" },
                values: new object[] { new Guid("2f9bedec-cd5d-44da-b257-f75be9e37718"), 1, "", new DateTime(2023, 2, 13, 19, 19, 50, 898, DateTimeKind.Local).AddTicks(5598), "", null, 0, 0, 0, false, null, "", null, 2, "Akeem", 0, 0, new DateTime(2023, 2, 13, 19, 19, 50, 898, DateTimeKind.Local).AddTicks(5630) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MASFlights",
                keyColumn: "Id",
                keyValue: new Guid("2f9bedec-cd5d-44da-b257-f75be9e37718"));
        }
    }
}
