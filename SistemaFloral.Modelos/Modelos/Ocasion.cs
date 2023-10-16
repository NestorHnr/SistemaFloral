using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.Modelos.Modelos
{
    public class Ocasion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(60,ErrorMessage ="Nombre debe contener maximo 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion es requerido")]
        [MaxLength(100,ErrorMessage ="Descripcion debe contener maximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Estado es requerido")]
        public bool Estado { get; set; }
    }
}
