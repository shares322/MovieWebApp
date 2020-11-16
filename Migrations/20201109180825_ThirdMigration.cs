using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieWebApp.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieDB",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieDB",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieDB",
                keyColumn: "MovieId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieDB",
                keyColumn: "MovieId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieDB",
                keyColumn: "MovieId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieDB",
                keyColumn: "MovieId",
                keyValue: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MovieDB",
                columns: new[] { "MovieId", "Actors", "DateTime", "Directors", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, "River Phoenix", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rob Reiner", "Drama", "Stand by Me" },
                    { 2, "Jodi Benson", new DateTime(1989, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ron Clements", "Romance", "Little Mermaid" },
                    { 3, "Bill Murray", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harold Ramis", "Comedy", "Caddyshack" },
                    { 4, "Tom Hanks", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Lassete", "Comedy", "Toy Story" },
                    { 5, "James Badge Dale", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Prior", "Horror", "The Empty Man" },
                    { 6, "Michael J. Fox", new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Zemeckis", "Drama", "Back to the Future" }
                });
        }
    }
}
