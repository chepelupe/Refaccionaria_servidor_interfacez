using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LoginModel
    {
        [Required]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        public string Contrasena { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public string? Token { get; set; } // Para futuro JWT
        public string? NombreUsuario { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Rol { get; set; }
    }

    public class RegistrarUsuarioModel
    {
        [Required]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Contrasena { get; set; } = string.Empty;

        public string? NombreCompleto { get; set; }
        public string? Email { get; set; }
    }
}