using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecSaudeAH.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Secretaria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataCad = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Extensao = table.Column<string>(nullable: true),
                    SecretariaId = table.Column<int>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true),
                    LastLogin = table.Column<DateTime>(nullable: true),
                    DataCad = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Tipo = table.Column<int>(nullable: false),
                    Funcao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profissionais_Secretaria_SecretariaId",
                        column: x => x.SecretariaId,
                        principalTable: "Secretaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hospitais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataCad = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ProfissionalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitais_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    IsProprio = table.Column<bool>(nullable: false),
                    Sexo = table.Column<string>(nullable: true),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataCad = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ProfissionalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CNS = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    NomeMae = table.Column<string>(nullable: true),
                    DataNasc = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    ProfissionalId = table.Column<int>(nullable: false),
                    DataCad = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Procedimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    ValorMed = table.Column<string>(nullable: true),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataCad = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ProfissionalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedimentos_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataCad = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ProfissionalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidades_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitais_ProfissionalId",
                table: "Hospitais",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_ProfissionalId",
                table: "Medicos",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ProfissionalId",
                table: "Pacientes",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_ProfissionalId",
                table: "Procedimentos",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_SecretariaId",
                table: "Profissionais",
                column: "SecretariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_ProfissionalId",
                table: "Unidades",
                column: "ProfissionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospitais");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Procedimentos");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Secretaria");
        }
    }
}
