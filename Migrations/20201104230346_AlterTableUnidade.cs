using Microsoft.EntityFrameworkCore.Migrations;

namespace SecSaudeAH.Migrations
{
    public partial class AlterTableUnidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Unidades",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Unidades");
        }
    }
}
