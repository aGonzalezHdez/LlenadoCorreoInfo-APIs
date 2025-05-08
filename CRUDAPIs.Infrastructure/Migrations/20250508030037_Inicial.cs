using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRUDAPIs.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ejecutivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEmpleado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejecutivos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaLlegada = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraLlegada = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoCliente = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TituloCorreo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Partidas = table.Column<int>(type: "int", nullable: false),
                    FechaCierre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraCierre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiasRespuesta = table.Column<int>(type: "int", nullable: false),
                    Referencia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RazonSocial = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ComentariosId = table.Column<int>(type: "int", nullable: false),
                    AtendidoPorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Comentarios_ComentariosId",
                        column: x => x.ComentariosId,
                        principalTable: "Comentarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Ejecutivos_AtendidoPorId",
                        column: x => x.AtendidoPorId,
                        principalTable: "Ejecutivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "POR ASIGNAR" },
                    { 2, "CLIENTE" },
                    { 3, "COM. EXT" },
                    { 4, "COMERCIALIZADORA" },
                    { 5, "COTIZACIONES PARA COMERCIAL" },
                    { 6, "DHL" },
                    { 7, "Ei CARGA" },
                    { 8, "IOM DE MEXICO" },
                    { 9, "MSL" }
                });

            migrationBuilder.InsertData(
                table: "Comentarios",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "SIN COMENTARIOS" },
                    { 2, "APOYO A OTRA ÁREA" },
                    { 3, "BÚSQUEDA DE INFORMACIÓN PARA CLASIFICAR" },
                    { 4, "CATÁLOGO DE PRODUCTOS" },
                    { 5, "DINÁMICAS" },
                    { 6, "FALLA DEL SISTEMA" },
                    { 7, "FALTA DE INFORMACIÓN DEL CLIENTE" },
                    { 8, "MANTENIMIENTO EQUIPO" },
                    { 9, "MISCELÁNEA" },
                    { 10, "REUNIÓN" },
                    { 11, "VACACIONES / INCAPACIDAD / VACANTE" }
                });

            migrationBuilder.InsertData(
                table: "Ejecutivos",
                columns: new[] { "Id", "IdEmpleado", "Nombre" },
                values: new object[,]
                {
                    { 1, "000000", "POR ASIGNAR" },
                    { 2, "000000", "ALEJANDRA" },
                    { 3, "000000", "ROSARIO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_AtendidoPorId",
                table: "Consultas",
                column: "AtendidoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_ClienteId",
                table: "Consultas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_ComentariosId",
                table: "Consultas",
                column: "ComentariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Ejecutivos");
        }
    }
}
