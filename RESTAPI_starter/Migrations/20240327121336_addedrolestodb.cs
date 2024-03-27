using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RESTAPI_starter.Migrations
{
    /// <inheritdoc />
    public partial class addedrolestodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "206d6974-ef05-4351-b7fc-e012d1642250", null, "Manager", "MANAGER" },
                    { "f08d962c-52f3-4dfe-892b-e3a8e7b75e20", null, "Administrator", "ADMINSTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "206d6974-ef05-4351-b7fc-e012d1642250");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f08d962c-52f3-4dfe-892b-e3a8e7b75e20");
        }
    }
}
