using Microsoft.EntityFrameworkCore.Migrations;

namespace SecSaudeAH.Migrations
{
    public partial class AlterTableMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CRM",
                table: "Medicos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CRM",
                table: "Medicos");
        }
    }
}
