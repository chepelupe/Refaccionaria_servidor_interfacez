using Domain;
using infraestructura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RefaccionariaDbContext _context;

        public AuthController(RefaccionariaDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginModel login)
        {
            try
            {
                // Buscar usuario por nombre de usuario (texto plano por ahora)
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.NombreUsuario == login.NombreUsuario);

                if (usuario == null)
                {
                    return Ok(new LoginResponse
                    {
                        Exitoso = false,
                        Mensaje = "Usuario o contraseña incorrectos"
                    });
                }

                // Comparar contraseña en texto plano
                if (usuario.ContrasenaHash != login.Contrasena)
                {
                    return Ok(new LoginResponse
                    {
                        Exitoso = false,
                        Mensaje = "Usuario o contraseña incorrectos"
                    });
                }

                // Como no tenemos los campos adicionales en la BD, asignamos valores por defecto
                return Ok(new LoginResponse
                {
                    Exitoso = true,
                    Mensaje = "Login exitoso",
                    NombreUsuario = usuario.NombreUsuario,
                    NombreCompleto = usuario.NombreUsuario, // Usamos el nombre de usuario
                    Rol = "Usuario" // Rol por defecto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new LoginResponse
                {
                    Exitoso = false,
                    Mensaje = $"Error del servidor: {ex.Message}"
                });
            }
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<LoginResponse>> Registrar([FromBody] RegistrarUsuarioModel registro)
        {
            try
            {
                // Verificar si el usuario ya existe
                var existe = await _context.Usuarios
                    .AnyAsync(u => u.NombreUsuario == registro.NombreUsuario);

                if (existe)
                {
                    return Ok(new LoginResponse
                    {
                        Exitoso = false,
                        Mensaje = "El nombre de usuario ya existe"
                    });
                }

                // Crear nuevo usuario (guardando contraseña en texto plano)
                var usuario = new Usuario
                {
                    NombreUsuario = registro.NombreUsuario,
                    ContrasenaHash = registro.Contrasena, // Texto plano directamente
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return Ok(new LoginResponse
                {
                    Exitoso = true,
                    Mensaje = "Usuario registrado exitosamente",
                    NombreUsuario = usuario.NombreUsuario,
                    NombreCompleto = usuario.NombreUsuario,
                    Rol = "Usuario"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new LoginResponse
                {
                    Exitoso = false,
                    Mensaje = $"Error del servidor: {ex.Message}"
                });
            }
        }

        // Método opcional para listar todos los usuarios
        [HttpGet("usuarios")]
        public async Task<ActionResult<IEnumerable<object>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Select(u => new { u.IdUsuario, u.NombreUsuario })
                .ToListAsync();
            
            return Ok(usuarios);
        }
    }
}