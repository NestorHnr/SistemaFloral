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
    public class OcasionRepositorio : Repositorio<Ocasion>, IOcasionRepositorio
    {
        private readonly ApplicationDbContext _db;

        public OcasionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Ocasion ocasion)
        {
            var ocasionDB = _db.Ocasiones.FirstOrDefault(x => x.Id == ocasion.Id);
            if (ocasionDB != null) 
            {
                ocasionDB.Nombre = ocasion.Nombre;
                ocasionDB.Descripcion = ocasion.Descripcion;
                ocasionDB.Estado = ocasion.Estado;
                _db.SaveChanges();
            }
        }
    }
}
