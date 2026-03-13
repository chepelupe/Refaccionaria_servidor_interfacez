using System.ComponentModel.DataAnnotations;
namespace Domain
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Rfc { get; set; }
        public long? NumeroTel { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public bool Estado { get; set; } = true;
    }
}