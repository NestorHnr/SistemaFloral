using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.Modelos.Modelos
{
    public class Producto
    {
        [Key]
        public int  Id { get; set; }

        [Required(ErrorMessage ="Numero de Serie es requerido")]
        [MaxLength(60)]
        public string NumeroSerie   { get; set; }

        [Required(ErrorMessage ="Nombre es requerido")]
        [MaxLength(60)]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Descripcion es requerida")]
        [MaxLength(80)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage ="Costo es requerido")]
        public double Costo { get; set; }

        public string ImagenUrl { get; set; }

        [Required(ErrorMessage ="Estado es requerido")]
        public bool Estado { get; set; }

        //Relaciones con otros modelos

        //propiedad
        [Required(ErrorMessage ="Cateroria es requerida")]
        public int CategoriaId { get; set; }

        //Navegacion: a que modelo quiere navegar con la propiedad creada
        [ForeignKey("CategoriaId")]
        public Categoria Categoria  { get; set; }

        [Required(ErrorMessage ="Ocasion es requerida")]
        public int OcasionId { get; set; }

        [ForeignKey("OcasionId")]
        public Ocasion Ocasion { get; set; }    

    }
}
