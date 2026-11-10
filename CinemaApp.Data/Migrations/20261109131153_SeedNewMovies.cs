using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ImageUrl", "IsDeleted", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("5c7e7b5f-9f2c-4a0f-8a8b-1e5d6c7f8a90"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", 175, "Crime", "https://m.media-amazon.com/images/M/MV5BMTFiYzQwNzctY2QzNC00N2EwLTllMzgtYzQxM2Q4YmY4YjQxXkEyXkFqcGc@._V1_.jpg", false, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("6d8f8c60-a03d-4b10-9b9c-2f6e7d8a9b01"), "A young FBI cadet seeks the help of an imprisoned and manipulative cannibal killer to catch another serial murderer.", "Jonathan Demme", 118, "Thriller", "https://m.media-amazon.com/images/M/MV5BNGFiY2Y4MDctYjM4NS00YzEwLWEyYjItN2I1NmM2NDk3YjFjXkEyXkFqcGc@._V1_.jpg", false, new DateTime(1991, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Silence of the Lambs" },
                    { new Guid("7e9a9d71-b14e-4c21-acad-3a7f8e9bac12"), "A prison guard discovers that a gentle giant on death row possesses a mysterious gift.", "Frank Darabont", 189, "Drama", "https://m.media-amazon.com/images/M/MV5BMTkxYzY3OTYtNGJkOC00M2YyLTg4ZDItYzM3M2Y2YzM4Y2QyXkEyXkFqcGc@._V1_.jpg", false, new DateTime(1999, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Green Mile" },
                    { new Guid("8fabae82-c25f-4d32-bdbe-4b809facbd23"), "An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang in Boston.", "Martin Scorsese", 151, "Crime", "https://m.media-amazon.com/images/M/MV5BMTM0NTQ2NjY0NV5BMl5BanBnXkFtZTcwMDkzMzQzMw@@._V1_.jpg", false, new DateTime(2006, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Departed" },
                    { new Guid("90bcbb93-d360-4e43-cecf-5c91a0bcde34"), "Two rival magicians engage in a bitter battle of secrets, sacrifice, and obsession in Victorian London.", "Christopher Nolan", 130, "Mystery", "https://m.media-amazon.com/images/M/MV5BMTM0NTQ2NjY0NV5BMl5BanBnXkFtZTcwMDkzMzQzMw@@._V1_.jpg", false, new DateTime(2006, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Prestige" },
                    { new Guid("a1cdcca4-e471-4f54-dfd0-6da2b1cede45"), "A promising young drummer enrolls at a cutthroat music conservatory where his demanding instructor pushes him to greatness.", "Damien Chazelle", 106, "Drama", "https://m.media-amazon.com/images/M/MV5BMTQ4NjQzNzA2OF5BMl5BanBnXkFtZTgwMDQ0NzgxMzE@._V1_.jpg", false, new DateTime(2014, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whiplash" },
                    { new Guid("b2deddb5-f582-4065-eed1-7eb3c2def056"), "A struggling family gradually infiltrates the household of a wealthy family with unexpected consequences.", "Bong Joon Ho", 132, "Thriller", "https://m.media-amazon.com/images/M/MV5BMTYwMTQ0NTYyNV5BMl5BanBnXkFtZTgwMTQ0NzQ4NjM@._V1_.jpg", false, new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parasite" },
                    { new Guid("c3efeed6-0693-4176-f0e2-8fc4d3ef1067"), "A young lion prince flees his kingdom after the death of his father and learns the true meaning of responsibility.", "Roger Allers, Rob Minkoff", 88, "Animation", "https://m.media-amazon.com/images/M/MV5BMTQ4NzA0NzQyNV5BMl5BanBnXkFtZTgwMTU0NjQxMzE@._V1_.jpg", false, new DateTime(1994, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lion King" },
                    { new Guid("d4f0ffe7-17a4-4287-a1f3-90d5e4f02178"), "A group of soldiers searches for a paratrooper whose brothers have been killed in combat during World War II.", "Steven Spielberg", 169, "War", "https://m.media-amazon.com/images/M/MV5BMTQ4NzA0NzQyNV5BMl5BanBnXkFtZTgwMTU0NjQxMzE@._V1_.jpg", false, new DateTime(1998, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saving Private Ryan" },
                    { new Guid("e50100f8-28b5-4398-b204-a1e6f5013289"), "A teenager travels back in time and accidentally interferes with the meeting of his parents.", "Robert Zemeckis", 116, "Adventure", "https://m.media-amazon.com/images/M/MV5BMTQ4NzA0NzQyNV5BMl5BanBnXkFtZTgwMTU0NjQxMzE@._V1_.jpg", false, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Back to the Future" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("5c7e7b5f-9f2c-4a0f-8a8b-1e5d6c7f8a90"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("6d8f8c60-a03d-4b10-9b9c-2f6e7d8a9b01"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7e9a9d71-b14e-4c21-acad-3a7f8e9bac12"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8fabae82-c25f-4d32-bdbe-4b809facbd23"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("90bcbb93-d360-4e43-cecf-5c91a0bcde34"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("a1cdcca4-e471-4f54-dfd0-6da2b1cede45"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b2deddb5-f582-4065-eed1-7eb3c2def056"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c3efeed6-0693-4176-f0e2-8fc4d3ef1067"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d4f0ffe7-17a4-4287-a1f3-90d5e4f02178"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e50100f8-28b5-4398-b204-a1e6f5013289"));
        }
    }
}
