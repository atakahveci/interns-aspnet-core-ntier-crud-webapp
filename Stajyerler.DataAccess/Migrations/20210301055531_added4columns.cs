using Microsoft.EntityFrameworkCore.Migrations;

namespace Stajyerler.DataAccess.Migrations
{
    public partial class added4columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Stajyers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Stajyers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "Stajyers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Stajyers",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Stajyers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Stajyers");

            migrationBuilder.DropColumn(
                name: "Major",
                table: "Stajyers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Stajyers");
        }
    }
}
