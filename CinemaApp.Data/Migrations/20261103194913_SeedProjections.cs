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
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b01"), 120, new Guid("e481ab5c-07f7-4c1c-a5eb-1307e757e6c6"), false, new Guid("4f7ad974-d137-4c0b-4d4c-08df2b6832ed"), new DateTime(2026, 12, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), 12.50m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b02"), 95, new Guid("e481ab5c-07f7-4c1c-a5eb-1307e757e6c6"), false, new Guid("ab2c3213-48a7-41ea-9393-45c60ef813e6"), new DateTime(2026, 12, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 14.00m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b03"), 80, new Guid("28e27378-6d13-484a-9652-e55b0c3d1d66"), false, new Guid("ab2c3213-48a7-41ea-9393-45c60ef813e6"), new DateTime(2026, 12, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 13.50m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b04"), 110, new Guid("c2e6c95c-a588-4cd8-8f7f-d11e7d6db49e"), false, new Guid("844d9abd-104d-41ab-b14a-ce059779ad91"), new DateTime(2026, 12, 2, 21, 30, 0, 0, DateTimeKind.Unspecified), 15.00m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b05"), 75, new Guid("c2e6c95c-a588-4cd8-8f7f-d11e7d6db49e"), false, new Guid("27af82a3-0609-423e-854e-fccdc0ff1e28"), new DateTime(2026, 12, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), 11.00m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b06"), 100, new Guid("1f904122-f663-4054-a2e1-593f06e1b43e"), false, new Guid("16376cc6-b3e0-4bf7-a0e4-9cbd1490522c"), new DateTime(2026, 12, 3, 20, 30, 0, 0, DateTimeKind.Unspecified), 14.50m },
                    { new Guid("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b07"), 90, new Guid("1f904122-f663-4054-a2e1-593f06e1b43e"), false, new Guid("777634e2-3bb6-4748-8e91-7a10b70c78ac"), new DateTime(2026, 12, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), 12.00m }
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
