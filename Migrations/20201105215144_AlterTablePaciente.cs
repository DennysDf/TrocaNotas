using Microsoft.EntityFrameworkCore.Migrations;

namespace SecSaudeAH.Migrations
{
    public partial class AlterTablePaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Pacientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Pacientes");
        }
    }
}
