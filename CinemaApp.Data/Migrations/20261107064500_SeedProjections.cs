using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProjections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projections",
                columns: new[] { "Id", "AvailableTickets", "CinemaId", "IsDeleted", "MovieId", "Showtime", "TicketPrice" },
                values: new object[,]
                {
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b01"), 120, new Guid("1F904122-F663-4054-A2E1-593F06E1B43E"), false, new Guid("E00208B1-CB12-4BD4-8AC1-36AB62F7B4C9"), new DateTime(2026, 12, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), 12.50m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b02"), 95, new Guid("1F904122-F663-4054-A2E1-593F06E1B43E"), false, new Guid("AE50A5AB-9642-466F-B528-3CC61071BB4C"), new DateTime(2026, 12, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 14.00m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b03"), 80, new Guid("344378CB-CC6C-446D-A513-E2C1B557BE55"), false, new Guid("54082F99-023B-4D68-89AC-44C00A0958D0"), new DateTime(2026, 12, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 13.50m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b04"), 110, new Guid("344378CB-CC6C-446D-A513-E2C1B557BE55"), false, new Guid("AB2C3213-48A7-41EA-9393-45C60EF813E6"), new DateTime(2026, 12, 2, 21, 30, 0, 0, DateTimeKind.Unspecified), 15.00m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b05"), 75, new Guid("E481AB5C-07F7-4C1C-A5EB-1307E757E6C6"), false, new Guid("AB2C3213-48A7-41EA-9393-45C60EF813E6"), new DateTime(2026, 12, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), 11.00m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b06"), 100, new Guid("28E27378-6D13-484A-9652-E55B0C3D1D66"), false, new Guid("AE50A5AB-9642-466F-B528-3CC61071BB4C"), new DateTime(2026, 12, 3, 20, 30, 0, 0, DateTimeKind.Unspecified), 14.50m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b07"), 90, new Guid("0B759211-0E62-49FC-BB13-2F0AED97F859"), false, new Guid("4491B6F5-2A11-4C4C-8C6B-C371F47D2152"), new DateTime(2026, 12, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), 12.00m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b08"), 90, new Guid("C2E6C95C-A588-4CD8-8F7F-D11E7D6DB49E"), false, new Guid("844D9ABD-104D-41AB-B14A-CE059779AD91"), new DateTime(2026, 12, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), 12.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b01"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b02"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b03"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b04"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b05"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b06"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b07"));
        }
    }
}
