using System.ComponentModel.DataAnnotations;
namespace Domain
{
    public class DetalleVenta
    {
        [Key]
        public int IdDetallesVentas { get; set; }
        public int FkVenta { get; set; }
        public int FkProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitarioVenta { get; set; }
        public decimal Subtotal { get; set; }

        // Propiedades de navegación (Relaciones)
        public Venta? Venta { get; set; }
        public Producto? Producto { get; set; }
    }
}