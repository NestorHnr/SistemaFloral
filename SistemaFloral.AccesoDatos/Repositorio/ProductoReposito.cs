using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaFloral.AccesoDatos.Data;
using SistemaFloral.AccesoDatos.Repositorio.IRepositorio;
using SistemaFloral.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.AccesoDatos.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Producto producto)
        {
            var productoDB = _db.Productos.FirstOrDefault(x => x.Id == producto.Id);
            if (productoDB != null) 
            {
                if (producto.ImagenUrl != null)
                {
                    productoDB.ImagenUrl = producto.ImagenUrl;
                }
                productoDB.NumeroSerie = producto.NumeroSerie;
                productoDB.Nombre = producto.Nombre;
                productoDB.Descripcion = producto.Descripcion;
                productoDB.Costo = producto.Costo;
                productoDB.CategoriaId = producto.CategoriaId;
                productoDB.OcasionId = producto.OcasionId;
                productoDB.Estado = producto.Estado;

                _db.SaveChanges();
            }
        }

        //Metodo encargado de llenar las listas 
        public IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj)
        {
            if (obj == "Categoria") 
            {
                return _db.Categorias.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }
            if (obj == "Ocasion") 
            {
                return _db.Ocasiones.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }
            return null;
        }
    }
}
