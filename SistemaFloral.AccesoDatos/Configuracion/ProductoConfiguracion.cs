using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaFloral.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.AccesoDatos.Configuracion
{
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder) 
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.NumeroSerie).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.Costo).IsRequired();
            builder.Property(x => x.CategoriaId).IsRequired();
            builder.Property(x => x.OcasionId).IsRequired();
            builder.Property(x => x.ImagenUrl).IsRequired(false);

            /*Relaciones entre tablas*/

            builder.HasOne(x => x.Categoria).WithMany()
                   .HasForeignKey(x => x.CategoriaId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Ocasion).WithMany()
                   .HasForeignKey(x => x.OcasionId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
