using Domain;
using infraestructura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly RefaccionariaDbContext _context;

        // Inyectamos la base de datos al controlador
        public ProductosController(RefaccionariaDbContext context)
        {
            _context = context;
        }

        // GET: api/productos (Para ver la lista de inventario)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // POST: api/productos (Para guardar un producto nuevo)
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync(); // Aquí viaja hasta Azure

            return Ok(producto);
        }
    }
}