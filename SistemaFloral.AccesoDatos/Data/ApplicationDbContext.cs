﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaFloral.Modelos.Modelos;
using System.Reflection;

namespace SistemaFloral.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Ocasion> Ocasiones { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<UsuarioAplicacion> UsuarioAplicacion { get; set; }
        public DbSet<BodegaProducto> BodegasProductos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<InventarioDetalle> InventarioDetalles { get; set; }
        public DbSet<KardexInventario> KardexInventarios { get; set; }
        public DbSet<Floristeria> Floristerias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}