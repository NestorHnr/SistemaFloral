﻿using Microsoft.EntityFrameworkCore;
using SistemaFloral.AccesoDatos.Data;
using SistemaFloral.AccesoDatos.Repositorio.IRepositorio;
using SistemaFloral.Modelos.Especificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.AccesoDatos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }


        public async Task Agregar(T entidad)
        {
            await dbSet.AddAsync(entidad); // insert into table
        }

        public async Task<T> Obtener(int id)
        {
            return await dbSet.FindAsync(id);  // Select * from (Solo por id)
        }
        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro = null, 
                                                       Func<IQueryable<T>, 
                                                       IOrderedQueryable<T>> OrderBy = null, 
                                                       string incluirPropiedades = null, 
                                                       bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            { 
                query = query.Where(filtro); // Select * from where
            }
            if (incluirPropiedades != null) 
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                        query = query.Include(incluirProp); // ejemplo "Categoria, Ocasiones"
                }
            }
            if (OrderBy != null) 
            {
                query = OrderBy(query); // ordenamos
            }
            if (!isTracking) 
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();   
        }

        public PagedList<T> ObtenerTodosPaginados(Parametros parametros, Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro); // Select * from where
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // ejemplo "Categoria, Ocasiones"
                }
            }
            if (OrderBy != null)
            {
                query = OrderBy(query); // ordenamos
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return PagedList<T>.ToPagedList(query, parametros.PageNumber, parametros.PageSize);
        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro); // Select * from where
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // ejemplo "Categoria, Ocasiones"
                }
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();
        }


        public void Remover(T entidad)
        {
            dbSet.Remove(entidad);
        }

        public void RemoverRango(IEnumerable<T> entidad)
        {
            dbSet.RemoveRange(entidad);
        }

       
    }
}
