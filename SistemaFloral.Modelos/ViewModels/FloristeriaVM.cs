using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaFloral.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.Modelos.ViewModels
{
    public class FloristeriaVM
    {
        public Floristeria Floristeria { get; set; }

        public IEnumerable<SelectListItem> BodegaLista { get; set; }
    }
}
