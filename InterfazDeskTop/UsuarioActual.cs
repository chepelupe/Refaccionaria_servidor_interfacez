using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazDeskTop
{
    public static class UsuarioActual
    {
        public static string NombreUsuario { get; set; }
        public static string NombreCompleto { get; set; }
        public static string Rol { get; set; }

        public static bool EstaAutenticado => !string.IsNullOrEmpty(NombreUsuario);

        public static void CerrarSesion()
        {
            NombreUsuario = null;
            NombreCompleto = null;
            Rol = null;
        }
    }
}
