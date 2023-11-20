using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.Modelos.Modelos
{
    public class Floristeria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es Requerido")]
        [MaxLength(80)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion es Requerida")]
        [MaxLength(200)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Pais es Requerido")]
        [MaxLength(60)]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Ciudad es Requerida")]
        [MaxLength(60)]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Direccion es Requerida")]
        [MaxLength(100)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Telefono es Requerido")]
        [MaxLength(40)]
        public string Telefono { get; set; }

        public string WhatsAppUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        //Navegacion con la Bodega
        [Required(ErrorMessage = "Bodega de venta es Requerida")]
        public int BodegaVentaId { get; set; }

        [ForeignKey("BodegaVentaId")]
        public Bodega Bodega { get; set; }

        //Navegacion con el Usuario para creacion
        public string CreadoPorId { get; set; }

        [ForeignKey("CreadoProId")]
        public UsuarioAplicacion CreadoPor { get; set; }

        //Navegacion con el Usuario para Actualizacion
        public string ActualizadoPorId { get; set; }

        [ForeignKey("ActualizadoProId")]
        public UsuarioAplicacion ActualizadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}
