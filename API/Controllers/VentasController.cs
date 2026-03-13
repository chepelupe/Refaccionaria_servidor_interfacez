using Domain;
using infraestructura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly RefaccionariaDbContext _context;

        public VentasController(RefaccionariaDbContext context)
        {
            _context = context;
        }

        // Clase auxiliar para recibir la Venta y sus Detalles al mismo tiempo desde el Frontend
        public class VentaRequest
        {
            public Venta Venta { get; set; } = null!;
            public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarVenta([FromBody] VentaRequest request)
        {
            // Iniciamos una transacción. Si algo falla, se cancela TODO y la base de datos queda intacta.
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. Guardar la cabecera de la venta (Fecha, Totales, etc.)
                _context.Ventas.Add(request.Venta);
                await _context.SaveChangesAsync(); // Al guardar, Azure le asigna su IdVenta automáticamente

                // 2. Recorrer la lista de productos que el cliente está comprando
                foreach (var detalle in request.Detalles)
                {
                    // Le decimos a cada detalle a qué Venta pertenece
                    detalle.FkVenta = request.Venta.IdVenta;
                    _context.DetallesVentas.Add(detalle);

                    // 3. ¡LA MAGIA DEL INVENTARIO! Buscamos el producto en la BD y le restamos lo que se vendió
                    var productoEnDb = await _context.Productos.FindAsync(detalle.FkProducto);
                    if (productoEnDb != null)
                    {
                        productoEnDb.StockActual -= detalle.Cantidad;
                    }
                }

                // Guardamos los detalles y la actualización del inventario
                await _context.SaveChangesAsync();

                // Confirmamos que todo salió perfecto
                await transaction.CommitAsync();

                return Ok(new { Mensaje = "Venta registrada con éxito", IdGenerado = request.Venta.IdVenta });
            }
            catch (Exception ex)
            {
                // Si hubo un error (ej. base de datos caída), deshacemos todo para evitar datos a medias
                await transaction.RollbackAsync();
                return BadRequest("Hubo un error al procesar la venta: " + ex.Message);
            }
        }
    }
}