using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IBodegaRepositorio Bodega { get; }
        ICategoriaRepositorio Categoria { get; }
        IOcasionRepositorio Ocasion { get; }

        Task Guardar();
    }
}
