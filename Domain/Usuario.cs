using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
	[Table("Usuarios")]
	public class Usuario
	{
		[Key]
    		[Column("id")]
    		public int IdUsuario { get; set; }

    		[Column("usuario")]
    		public string NombreUsuario { get; set; } = string.Empty;

    		[Column("contraseña")]
    		public string ContrasenaHash { get; set; } = string.Empty;
	}
}