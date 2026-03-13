using Domain;
using infraestructura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposProductosController : ControllerBase
    {
        private readonly RefaccionariaDbContext _context;

        public TiposProductosController(RefaccionariaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoProducto>>> GetTiposProductos()
        {
            return await _context.TiposProductos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TipoProducto>> PostTipoProducto(TipoProducto tipoProducto)
        {
            _context.TiposProductos.Add(tipoProducto);
            await _context.SaveChangesAsync();
            return Ok(tipoProducto);
        }
    }
}