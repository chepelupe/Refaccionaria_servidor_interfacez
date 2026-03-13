using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }

        public int FkProveedor { get; set; }
        public int FkMarca { get; set; }
        public int? FkTipoProducto { get; set; }

        public string? Modelo { get; set; }
        public int StockActual { get; set; }
        public int? StockMinimo { get; set; }
        public int? StockMaximo { get; set; }
        public string? CodigoBarras { get; set; }

        // Propiedades de navegación (Relaciones)
        public Proveedor? Proveedor { get; set; }
        public Marca? Marca { get; set; }
        public TipoProducto? TipoProducto { get; set; }
    }
}
