using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Resenas_CQS.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracionResena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resena",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaResena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JuegoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resena", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resena_Juego_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juego",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resena_JuegoId",
                table: "Resena",
                column: "JuegoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resena");
        }
    }
}
