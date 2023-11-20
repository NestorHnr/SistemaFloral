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
    public class FloristeriaConfiguracion : IEntityTypeConfiguration<Floristeria>
    {
        public void Configure(EntityTypeBuilder<Floristeria> builder) 
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Pais).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Ciudad).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefono).IsRequired();
            builder.Property(x => x.WhatsAppUrl).IsRequired(false);
            builder.Property(x => x.FacebookUrl).IsRequired(false);
            builder.Property(x => x.InstagramUrl).IsRequired(false);
            builder.Property(x => x.BodegaVentaId).IsRequired();
            builder.Property(x => x.CreadoPorId).IsRequired(false);
            builder.Property(x => x.ActualizadoPorId).IsRequired(false);


            /*Relaciones*/

            builder.HasOne(x => x.Bodega).WithMany()
                   .HasForeignKey(x => x.BodegaVentaId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.CreadoPor).WithMany()
                   .HasForeignKey(x => x.CreadoPorId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ActualizadoPor).WithMany()
                   .HasForeignKey(x => x.ActualizadoPorId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
