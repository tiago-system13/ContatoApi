using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bdiRepositorio.Migrations
{
    public partial class criando_banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ContatoApi");

            migrationBuilder.CreateTable(
                name: "Contato",
                schema: "ContatoApi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contato_nome = table.Column<string>(maxLength: 60, nullable: false),
                    contato_sexo = table.Column<string>(maxLength: 1, nullable: false),
                    contato_dt_nascimento = table.Column<DateTime>(nullable: false),
                    contato_idade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contato",
                schema: "ContatoApi");
        }
    }
}
