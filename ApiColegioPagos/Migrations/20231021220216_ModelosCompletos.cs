using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiColegioPagos.Migrations
{
    /// <inheritdoc />
    public partial class ModelosCompletos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Globals",
                columns: table => new
                {
                    Glo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Glo_nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Glo_valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Globals", x => x.Glo_id);
                });

            migrationBuilder.CreateTable(
                name: "Pensiones",
                columns: table => new
                {
                    Pen_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pen_nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pen_valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pensiones", x => x.Pen_id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Est_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Est_cedula = table.Column<int>(type: "int", nullable: false),
                    Est_nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Est_direccion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Est_activo = table.Column<bool>(type: "bit", nullable: false),
                    Pen_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Est_id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Pensiones_Pen_id",
                        column: x => x.Pen_id,
                        principalTable: "Pensiones",
                        principalColumn: "Pen_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Pag_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pag_cuota = table.Column<int>(type: "int", nullable: false),
                    Est_id = table.Column<int>(type: "int", nullable: false),
                    Pen_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Pag_id);
                    table.ForeignKey(
                        name: "FK_Pagos_Estudiantes_Est_id",
                        column: x => x.Est_id,
                        principalTable: "Estudiantes",
                        principalColumn: "Est_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pagos_Pensiones_Pen_id",
                        column: x => x.Pen_id,
                        principalTable: "Pensiones",
                        principalColumn: "Pen_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_Pen_id",
                table: "Estudiantes",
                column: "Pen_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_Est_id",
                table: "Pagos",
                column: "Est_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_Pen_id",
                table: "Pagos",
                column: "Pen_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Globals");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Pensiones");
        }
    }
}
