using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alvin_P2_API.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    TiempoTotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposTareas",
                columns: table => new
                {
                    TareaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTareas", x => x.TareaId);
                });

            migrationBuilder.CreateTable(
                name: "ProyectosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProyectoId = table.Column<int>(nullable: false),
                    TareaId = table.Column<int>(nullable: false),
                    Tiempo = table.Column<int>(nullable: false),
                    Requerimento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TareaId", "Descripcion" },
                values: new object[] { 1, "Analisis de Sistemas" });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TareaId", "Descripcion" },
                values: new object[] { 2, "Diseño de Sistemas" });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TareaId", "Descripcion" },
                values: new object[] { 3, "Programación Aplicada" });

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_ProyectoId",
                table: "ProyectosDetalle",
                column: "ProyectoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProyectosDetalle");

            migrationBuilder.DropTable(
                name: "TiposTareas");

            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
