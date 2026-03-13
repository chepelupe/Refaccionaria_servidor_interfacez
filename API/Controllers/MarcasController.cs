using Domain;
using infraestructura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly RefaccionariaDbContext _context;

        public MarcasController(RefaccionariaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            return await _context.Marcas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Marca>> PostMarca(Marca marca)
        {
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();
            return Ok(marca);
        }
    }
}