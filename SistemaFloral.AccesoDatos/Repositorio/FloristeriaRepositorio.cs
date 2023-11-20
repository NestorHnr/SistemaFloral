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
    public class FloristeriaRepositorio : Repositorio<Floristeria>, IFloristeriaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public FloristeriaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Floristeria floristeria)
        {
            var floristeriaDB = _db.Floristerias.FirstOrDefault(x => x.Id == floristeria.Id);
            if (floristeriaDB != null) 
            {
                floristeriaDB.Nombre = floristeria.Nombre;
                floristeriaDB.Descripcion = floristeria.Descripcion;
                floristeriaDB.Pais = floristeria.Pais;
                floristeriaDB.Ciudad = floristeria.Ciudad;
                floristeriaDB.Direccion = floristeria.Direccion;
                floristeriaDB.Telefono = floristeria.Telefono;
                floristeriaDB.WhatsAppUrl = floristeria.WhatsAppUrl;
                floristeriaDB.FacebookUrl = floristeria.FacebookUrl;
                floristeriaDB.InstagramUrl = floristeria.InstagramUrl;
                floristeriaDB.BodegaVentaId = floristeria.BodegaVentaId;
                floristeriaDB.ActualizadoPorId = floristeria.ActualizadoPorId;
                floristeriaDB.FechaActualizacion = floristeria.FechaActualizacion;



                _db.SaveChanges();
            }
        }
    }
}
