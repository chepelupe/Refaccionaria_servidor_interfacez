using Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace infraestructura
{
    // Heredar de DbContext le da a esta clase superpoderes para conectarse a SQL
    public class RefaccionariaDbContext : DbContext
    {
        // Este constructor es necesario para pasarle la cadena de conexión de Azure más adelante
        public RefaccionariaDbContext(DbContextOptions<RefaccionariaDbContext> options) : base(options)
        {
        }

        // Estas propiedades "DbSet" representan las tablas en tu base de datos.
        // EF Core leerá las clases de tu 'Domain' y creará las columnas correspondientes.
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVentas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoProducto> TiposProductos { get; set; }
    }
}