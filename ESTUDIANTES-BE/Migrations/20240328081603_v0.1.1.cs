using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESTUDIANTES_BE.Migrations
{
    public partial class v011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instructor",
                table: "Nota");

            migrationBuilder.AddColumn<int>(
                name: "IdInstructor",
                table: "Nota",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdInstructor",
                table: "Nota");

            migrationBuilder.AddColumn<string>(
                name: "Instructor",
                table: "Nota",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
