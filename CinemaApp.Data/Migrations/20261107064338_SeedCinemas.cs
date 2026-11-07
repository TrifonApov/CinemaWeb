using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCinemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("0b759211-0e62-49fc-bb13-2f0aed97f859"), false, "Ruse", "Arena Ruse" },
                    { new Guid("1f904122-f663-4054-a2e1-593f06e1b43e"), false, "Sofia", "House of Cinema" },
                    { new Guid("2887e121-180c-4da4-a46e-764e8f02441c"), false, "Sofia", "Cinema City Sofia" },
                    { new Guid("28e27378-6d13-484a-9652-e55b0c3d1d66"), false, "Plovdiv", "Cinema City Plovdiv" },
                    { new Guid("344378cb-cc6c-446d-a513-e2c1b557be55"), false, "Sofia", "Odeon" },
                    { new Guid("c2e6c95c-a588-4cd8-8f7f-d11e7d6db49e"), false, "Varna", "Cinema City Varna" },
                    { new Guid("e481ab5c-07f7-4c1c-a5eb-1307e757e6c6"), false, "Burgas", "Arena Burgas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("0b759211-0e62-49fc-bb13-2f0aed97f859"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("1f904122-f663-4054-a2e1-593f06e1b43e"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("2887e121-180c-4da4-a46e-764e8f02441c"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("28e27378-6d13-484a-9652-e55b0c3d1d66"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("344378cb-cc6c-446d-a513-e2c1b557be55"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("c2e6c95c-a588-4cd8-8f7f-d11e7d6db49e"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("e481ab5c-07f7-4c1c-a5eb-1307e757e6c6"));
        }
    }
}
