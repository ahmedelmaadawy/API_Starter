using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RESTAPI_starter.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "cairo", "Egypt", "Admin_Solutions Ltd" },
                    { new Guid("c9d4c053-49b6-410c-938c-2d54a9991870"), "583 wall Dr. Gwynn oak, MD 21207", "USA", "IT_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("c8cea98b-118a-47d4-b0f8-5fcdfe4d9aef"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Chandler Bing", "data configuration" },
                    { new Guid("fce0e256-1660-4048-a703-faa73353b726"), 24, new Guid("c9d4c053-49b6-410c-938c-2d54a9991870"), "Ahmed Mohamed", "Software Developer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c8cea98b-118a-47d4-b0f8-5fcdfe4d9aef"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("fce0e256-1660-4048-a703-faa73353b726"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("c9d4c053-49b6-410c-938c-2d54a9991870"));
        }
    }
}
