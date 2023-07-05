using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "colores",
                columns: table => new
                {
                    Colorid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colores", x => x.Colorid);
                });

            migrationBuilder.CreateTable(
                name: "propietarios",
                columns: table => new
                {
                    Propietarioid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propietarios", x => x.Propietarioid);
                });

            migrationBuilder.CreateTable(
                name: "autos",
                columns: table => new
                {
                    Autoid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Propietarioid = table.Column<int>(type: "int", nullable: false),
                    Colorid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autos", x => x.Autoid);
                    table.ForeignKey(
                        name: "FK_autos_colores_Colorid",
                        column: x => x.Colorid,
                        principalTable: "colores",
                        principalColumn: "Colorid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_autos_propietarios_Propietarioid",
                        column: x => x.Propietarioid,
                        principalTable: "propietarios",
                        principalColumn: "Propietarioid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_autos_Colorid",
                table: "autos",
                column: "Colorid");

            migrationBuilder.CreateIndex(
                name: "IX_autos_Propietarioid",
                table: "autos",
                column: "Propietarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "autos");

            migrationBuilder.DropTable(
                name: "colores");

            migrationBuilder.DropTable(
                name: "propietarios");
        }
    }
}
