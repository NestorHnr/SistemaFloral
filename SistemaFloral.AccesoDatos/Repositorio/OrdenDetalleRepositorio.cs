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
    public class OrdenDetalleRepositorio : Repositorio<OrdenDetalle>, IOrdenDetalleRepositorio
    {
        private readonly ApplicationDbContext _db;

        public OrdenDetalleRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(OrdenDetalle ordenDetalle)
        {
           _db.Update(ordenDetalle);
        }
    }
}
