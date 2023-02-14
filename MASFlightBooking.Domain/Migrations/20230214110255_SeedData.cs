using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MASFlightBooking.Domain.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MASFlights",
                keyColumn: "Id",
                keyValue: new Guid("2f9bedec-cd5d-44da-b257-f75be9e37718"));

            migrationBuilder.RenameColumn(
                name: "Number_of_passanger",
                table: "MASFlights",
                newName: "Number_of_Passanger");

            migrationBuilder.RenameColumn(
                name: "TravelerAge",
                table: "MASFlights",
                newName: "TravelersAge");

            migrationBuilder.InsertData(
                table: "MASFlights",
                columns: new[] { "Id", "Airline", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Departure", "Destination", "FlightCategories", "IsDeleted", "MobileNumber", "ModifiedBy", "ModifiedOn", "Number_of_Passanger", "TicketName", "TravelersAge", "TripType", "UpdatedOn" },
                values: new object[] { new Guid("43738933-acf0-4479-8624-0ef1bec0383d"), 1, "", new DateTime(2023, 2, 14, 12, 2, 54, 890, DateTimeKind.Local).AddTicks(735), "", null, 0, 0, 0, false, null, "", null, 1, "Akeem Mustapha", 0, 0, new DateTime(2023, 2, 14, 12, 2, 54, 890, DateTimeKind.Local).AddTicks(766) });

            migrationBuilder.InsertData(
                table: "MASFlights",
                columns: new[] { "Id", "Airline", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Departure", "Destination", "FlightCategories", "IsDeleted", "MobileNumber", "ModifiedBy", "ModifiedOn", "Number_of_Passanger", "TicketName", "TravelersAge", "TripType", "UpdatedOn" },
                values: new object[] { new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"), 0, "", new DateTime(2023, 2, 14, 12, 2, 54, 890, DateTimeKind.Local).AddTicks(781), "", null, 0, 0, 0, false, null, "", null, 2, "Oluwaseyi Kolawole", 0, 0, new DateTime(2023, 2, 14, 12, 2, 54, 890, DateTimeKind.Local).AddTicks(787) });

            migrationBuilder.InsertData(
                table: "MASFlights",
                columns: new[] { "Id", "Airline", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Departure", "Destination", "FlightCategories", "IsDeleted", "MobileNumber", "ModifiedBy", "ModifiedOn", "Number_of_Passanger", "TicketName", "TravelersAge", "TripType", "UpdatedOn" },
                values: new object[] { new Guid("923a643a-9c41-464e-9fe3-29656c34e589"), 4, "", new DateTime(2023, 2, 14, 12, 2, 54, 890, DateTimeKind.Local).AddTicks(797), "", null, 0, 0, 0, false, null, "", null, 3, "Bolu Adefalu", 0, 0, new DateTime(2023, 2, 14, 12, 2, 54, 890, DateTimeKind.Local).AddTicks(801) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MASFlights",
                keyColumn: "Id",
                keyValue: new Guid("43738933-acf0-4479-8624-0ef1bec0383d"));

            migrationBuilder.DeleteData(
                table: "MASFlights",
                keyColumn: "Id",
                keyValue: new Guid("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"));

            migrationBuilder.DeleteData(
                table: "MASFlights",
                keyColumn: "Id",
                keyValue: new Guid("923a643a-9c41-464e-9fe3-29656c34e589"));

            migrationBuilder.RenameColumn(
                name: "Number_of_Passanger",
                table: "MASFlights",
                newName: "Number_of_passanger");

            migrationBuilder.RenameColumn(
                name: "TravelersAge",
                table: "MASFlights",
                newName: "TravelerAge");

            migrationBuilder.InsertData(
                table: "MASFlights",
                columns: new[] { "Id", "Airline", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Departure", "Destination", "FlightCategories", "IsDeleted", "MobileNumber", "ModifiedBy", "ModifiedOn", "Number_of_passanger", "TicketName", "TravelerAge", "TripType", "UpdatedOn" },
                values: new object[] { new Guid("2f9bedec-cd5d-44da-b257-f75be9e37718"), 1, "", new DateTime(2023, 2, 13, 19, 19, 50, 898, DateTimeKind.Local).AddTicks(5598), "", null, 0, 0, 0, false, null, "", null, 2, "Akeem", 0, 0, new DateTime(2023, 2, 13, 19, 19, 50, 898, DateTimeKind.Local).AddTicks(5630) });
        }
    }
}
