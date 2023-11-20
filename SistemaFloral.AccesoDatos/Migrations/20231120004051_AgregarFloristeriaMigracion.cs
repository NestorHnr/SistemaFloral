using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFloral.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarFloristeriaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Floristerias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    WhatsAppUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodegaVentaId = table.Column<int>(type: "int", nullable: false),
                    CreadoPorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ActualizadoPorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoProId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreadoProId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floristerias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floristerias_AspNetUsers_ActualizadoPorId",
                        column: x => x.ActualizadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Floristerias_AspNetUsers_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Floristerias_Bodegas_BodegaVentaId",
                        column: x => x.BodegaVentaId,
                        principalTable: "Bodegas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Floristerias_ActualizadoPorId",
                table: "Floristerias",
                column: "ActualizadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Floristerias_BodegaVentaId",
                table: "Floristerias",
                column: "BodegaVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Floristerias_CreadoPorId",
                table: "Floristerias",
                column: "CreadoPorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Floristerias");
        }
    }
}
