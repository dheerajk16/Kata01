using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FillForm.Migrations
{
    /// <inheritdoc />
    public partial class FieldNameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "FormData");

            migrationBuilder.AddColumn<int>(
                name: "YearOfJoin",
                table: "FormData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearOfJoin",
                table: "FormData");

            migrationBuilder.AddColumn<string>(
                name: "DateOfBirth",
                table: "FormData",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
