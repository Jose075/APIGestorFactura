using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorFactura.Infrastructure.Migrations
{
    public partial class AddEntidadesFacuturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creadoPor = table.Column<string>(nullable: true),
                    creado = table.Column<DateTime>(nullable: false),
                    ultimaVezModificadoPor = table.Column<string>(nullable: true),
                    ultimaVezModificado = table.Column<DateTime>(nullable: true),
                    numeroFactura = table.Column<string>(nullable: true),
                    logo = table.Column<string>(nullable: true),
                    proviene = table.Column<string>(nullable: true),
                    hacia = table.Column<string>(nullable: true),
                    fecha = table.Column<DateTime>(nullable: false),
                    terminosDePago = table.Column<string>(nullable: true),
                    FechadeVencimiento = table.Column<DateTime>(nullable: true),
                    descuento = table.Column<double>(nullable: false),
                    TipoDescuento = table.Column<int>(nullable: false),
                    impuesto = table.Column<double>(nullable: false),
                    TipoImpuesto = table.Column<int>(nullable: false),
                    MontoPagado = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductoFacturas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creadoPor = table.Column<string>(nullable: true),
                    creado = table.Column<DateTime>(nullable: false),
                    ultimaVezModificadoPor = table.Column<string>(nullable: true),
                    ultimaVezModificado = table.Column<DateTime>(nullable: true),
                    idFactura = table.Column<int>(nullable: false),
                    producto = table.Column<string>(nullable: true),
                    cantidad = table.Column<double>(nullable: false),
                    tipo = table.Column<double>(nullable: false),
                    facturaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoFacturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoFacturas_Facturas_facturaid",
                        column: x => x.facturaid,
                        principalTable: "Facturas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoFacturas_facturaid",
                table: "ProductoFacturas",
                column: "facturaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoFacturas");

            migrationBuilder.DropTable(
                name: "Facturas");
        }
    }
}
