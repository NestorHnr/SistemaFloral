
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
    public class BodegaProductoRepositorio : Repositorio<BodegaProducto>, IBodegaProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public BodegaProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(BodegaProducto bodegaProducto)
        {
            var bodegaProductoDB = _db.BodegasProductos.FirstOrDefault(x => x.Id == bodegaProducto.Id);
            if (bodegaProductoDB != null) 
            {
                
                bodegaProductoDB.Cantidad = bodegaProducto.Cantidad;

                _db.SaveChanges();
            }
        }

    }
}
