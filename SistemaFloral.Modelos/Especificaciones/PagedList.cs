using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFloral.Modelos.Especificaciones
{
    public class PagedList<T>: List<T>
    {
        public MetaData MetaData { get; set; }


        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData 
            {
                TotalCount = count,
                PageSizes = pageSize,
                TotalPages = (int)Math.Ceiling(count/(double)pageSize) //Por ejemplo 1.5 lo trasnforma en 2
            };
            AddRange(items); //Agrega los elementos de la colleccion al final de la lista
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> entidad, int pageNumber, int pageSize) 
        {
            var count = entidad.Count();
            var items = entidad.Skip((pageNumber - 1)*pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
