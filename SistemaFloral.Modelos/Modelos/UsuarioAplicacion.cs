
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.Modelos.Modelos
{
    public class UsuarioAplicacion : IdentityUser
    {
        [Required(ErrorMessage = "Nombes son Requerido")]
        [MaxLength(80)]
        public string Nombres { get; set; }


        [Required(ErrorMessage = "Apellidos son Requerido")]
        [MaxLength(80)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Direccion es Requerida")]
        [MaxLength(100)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ciudad es Requerida")]
        [MaxLength(60)]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Pais es Requerido")]
        [MaxLength(60)]
        public string Pais { get; set; }

        [NotMapped] //no permite que la propuiedad se agregue a la base de datos
        public string Role { get; set; }


    }
}
