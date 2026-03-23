﻿using Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace infraestructura
{
    public class RefaccionariaDbContext : DbContext
    {
        public RefaccionariaDbContext(DbContextOptions<RefaccionariaDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVentas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoProducto> TiposProductos { get; set; }
        
        // NUEVA TABLA DE USUARIOS
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración adicional si es necesaria
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();
        }
    }
}