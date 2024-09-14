using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userpetsfix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "UserPets", "Username" },
                values: new object[,]
                {
                    { new Guid("b2a8c621-5e12-4c0b-8d3f-b1fbc9dfe9b7"), "jane.smith@example.com", "hashed_password456", "[\"32e7a77e-0146-4b15-b7f8-58c447641910\",\"ab16dbca-ef93-4c7b-855d-774f89cfab69\"]", "jane_smith" },
                    { new Guid("c3b9d721-6f23-4d2c-8e4f-c2fbc9dfea89"), "alice.johnson@example.com", "hashed_password789", "[]", "alice_johnson" },
                    { new Guid("d1a7c621-4c36-4c0b-8a3d-b0fbc9dfe8a6"), "john.doe@example.com", "hashed_password123", "[\"5acb1435-8cc9-42e4-a365-dfa8f9c88d26\"]", "john_doe" },
                    { new Guid("d4c8e831-7a34-4e3d-8f5e-d3fbc9dfeab0"), "bob.brown@example.com", "hashed_password012", "[\"0d8e8e7e-0145-4b20-bb9f-58c447641912\"]", "bob_brown" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b2a8c621-5e12-4c0b-8d3f-b1fbc9dfe9b7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c3b9d721-6f23-4d2c-8e4f-c2fbc9dfea89"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a7c621-4c36-4c0b-8a3d-b0fbc9dfe8a6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4c8e831-7a34-4e3d-8f5e-d3fbc9dfeab0"));
        }
    }
}
