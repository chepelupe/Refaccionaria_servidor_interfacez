using System.ComponentModel.DataAnnotations;
using System;

namespace Domain
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal MontoRecibido { get; set; }
        public decimal CambioEntregado { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
    }
}