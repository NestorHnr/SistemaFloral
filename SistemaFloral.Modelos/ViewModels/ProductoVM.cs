using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaFloral.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.Modelos.ViewModels
{
     public class ProductoVM
    {

        public Producto Producto { get; set; }

        public IEnumerable<SelectListItem> CategoriaLista { get; set; }

        public IEnumerable<SelectListItem> OcasionLista { get; set; }
    }
}
