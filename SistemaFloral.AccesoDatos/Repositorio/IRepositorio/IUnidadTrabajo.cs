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
        IProductoRepositorio Producto { get; }
        IUsuarioAplicacionRepositorio UsuarioAplicacion { get; }
        IBodegaProductoRepositorio BodegaProducto { get; }
        IInventarioRepositorio Inventario { get; }
        IInventarioDetalleRepositorio InventarioDetalle { get; }
        IKardexInventarioRepositorio KardexInventario { get; }
        IFloristeriaRepositorio Floristeria { get; }
        ICarroCompraRepositorio CarroCompra { get; }
        IOrdenRepositorio Orden { get; }
        IOrdenDetalleRepositorio OrdenDetalle { get; }

        Task Guardar();
    }
}
