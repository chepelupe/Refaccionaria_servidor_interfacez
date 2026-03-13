using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTel = table.Column<long>(type: "bigint", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "TiposProductos",
                columns: table => new
                {
                    IdTipoProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProductos", x => x.IdTipoProducto);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoRecibido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CambioEntregado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.IdVenta);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FkProveedor = table.Column<int>(type: "int", nullable: false),
                    FkMarca = table.Column<int>(type: "int", nullable: false),
                    FkTipoProducto = table.Column<int>(type: "int", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockActual = table.Column<int>(type: "int", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: true),
                    StockMaximo = table.Column<int>(type: "int", nullable: true),
                    CodigoBarras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProveedorIdProveedor = table.Column<int>(type: "int", nullable: true),
                    MarcaIdMarca = table.Column<int>(type: "int", nullable: true),
                    TipoProductoIdTipoProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_MarcaIdMarca",
                        column: x => x.MarcaIdMarca,
                        principalTable: "Marcas",
                        principalColumn: "IdMarca");
                    table.ForeignKey(
                        name: "FK_Productos_Proveedores_ProveedorIdProveedor",
                        column: x => x.ProveedorIdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IdProveedor");
                    table.ForeignKey(
                        name: "FK_Productos_TiposProductos_TipoProductoIdTipoProducto",
                        column: x => x.TipoProductoIdTipoProducto,
                        principalTable: "TiposProductos",
                        principalColumn: "IdTipoProducto");
                });

            migrationBuilder.CreateTable(
                name: "DetallesVentas",
                columns: table => new
                {
                    IdDetallesVentas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkVenta = table.Column<int>(type: "int", nullable: false),
                    FkProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitarioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VentaIdVenta = table.Column<int>(type: "int", nullable: true),
                    ProductoIdProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesVentas", x => x.IdDetallesVentas);
                    table.ForeignKey(
                        name: "FK_DetallesVentas_Productos_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto");
                    table.ForeignKey(
                        name: "FK_DetallesVentas_Ventas_VentaIdVenta",
                        column: x => x.VentaIdVenta,
                        principalTable: "Ventas",
                        principalColumn: "IdVenta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVentas_ProductoIdProducto",
                table: "DetallesVentas",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVentas_VentaIdVenta",
                table: "DetallesVentas",
                column: "VentaIdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaIdMarca",
                table: "Productos",
                column: "MarcaIdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedorIdProveedor",
                table: "Productos",
                column: "ProveedorIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoIdTipoProducto",
                table: "Productos",
                column: "TipoProductoIdTipoProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesVentas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "TiposProductos");
        }
    }
}
