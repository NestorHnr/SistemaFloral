using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaFloral.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.AccesoDatos.Repositorio.IRepositorio
{
    public interface IBodegaProductoRepositorio : IRepositorio<BodegaProducto>
    {
        void Actualizar(BodegaProducto bodegaProducto);

    }
}
