using System.ComponentModel.DataAnnotations;
namespace Domain
{
    public class TipoProducto
    {
        [Key]
        public int IdTipoProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
    }
}