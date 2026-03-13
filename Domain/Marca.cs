using System.ComponentModel.DataAnnotations;
namespace Domain
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Estatus { get; set; } = true;
    }
}