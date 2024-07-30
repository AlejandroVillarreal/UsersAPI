using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserAPI.Infrastructure.UserAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Species = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Habitat = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<float>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "DateOfBirth", "Description", "Habitat", "Name", "Species", "Weight" },
                values: new object[,]
                {
                    { new Guid("32e7a77e-0146-4b15-b7f8-58c447641910"), 1, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "A small house mouse.", "Houses", "Mickey", "Mouse", 30f },
                    { new Guid("5acb1435-8cc9-42e4-a365-dfa8f9c88d26"), 2, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "A common city rat.", "Urban Areas", "Ratty", "Rat", 250f },
                    { new Guid("ab16dbca-ef93-4c7b-855d-774f89cfab69"), 3, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "A forest chipmunk with distinctive stripes.", "Forests", "Chippy", "Chipmunk", 100f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
