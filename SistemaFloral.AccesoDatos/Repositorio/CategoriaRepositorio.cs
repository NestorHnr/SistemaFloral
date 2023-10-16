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
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Categoria categoria)
        {
            var catrtegoriaDB = _db.Bodegas.FirstOrDefault(x => x.Id == categoria.Id);
            if (catrtegoriaDB != null) 
            {
                catrtegoriaDB.Nombre = categoria.Nombre;
                catrtegoriaDB.Descripcion = categoria.Descripcion;
                catrtegoriaDB.Estado = categoria.Estado;
                _db.SaveChanges();
            }
        }
    }
}
