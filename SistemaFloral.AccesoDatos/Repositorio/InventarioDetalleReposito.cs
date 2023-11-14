
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
    public class InventarioDetalleRepositorio : Repositorio<InventarioDetalle>, IInventarioDetalleRepositorio
    {
        private readonly ApplicationDbContext _db;

        public InventarioDetalleRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(InventarioDetalle inventarioDetalle)
        {
            var inventarioDetalleDB = _db.InventarioDetalles.FirstOrDefault(x => x.Id == inventarioDetalle.Id);
            if (inventarioDetalleDB != null) 
            {
                
                inventarioDetalleDB.StockAnterior = inventarioDetalle.StockAnterior;
                inventarioDetalleDB.Cantidad = inventarioDetalle.Cantidad;

                _db.SaveChanges();
            }
        }

    }
}
