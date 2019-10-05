using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        ,
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false, defaultValue: true),
                    Nome = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        ,
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false, defaultValue: true),
                    Nome = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        ,
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 255, nullable: false),
                    ISBN = table.Column<string>(maxLength: 15, nullable: true),
                    Assunto = table.Column<string>(maxLength: 600, nullable: true),
                    Ano = table.Column<int>(nullable: false),
                    NumeroDePaginas = table.Column<int>(nullable: false),
                    QuantidadeEmEstoque = table.Column<int>(nullable: false),
                    Peso = table.Column<double>(nullable: false),
                    AutorId = table.Column<int>(nullable: false),
                    EditorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Editors_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AutorId",
                table: "Books",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_EditorId",
                table: "Books",
                column: "EditorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Editors");
        }
    }
}
