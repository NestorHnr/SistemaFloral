using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaFloral.AccesoDatos.Repositorio.IRepositorio;
using SistemaFloral.Modelos.Modelos;
using SistemaFloral.Utilidades;
using System.Data;

namespace SistemaFloral.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Admin)]
    public class OcasionController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;

        public OcasionController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id) 
        {
            Ocasion ocasion = new Ocasion();
            if (id == null) 
            {
                //crear una nueva bodega
                ocasion.Estado = true;
                return View(ocasion);
            }
            //Actualizar una bodega
            ocasion = await _unidadTrabajo.Ocasion.Obtener(id.GetValueOrDefault());
            if (ocasion == null) 
            {
                return NotFound();
            }
            return View(ocasion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult>Upsert(Ocasion ocasion) 
        {
            if (ModelState.IsValid)
            {
                if (ocasion.Id == 0)
                {
                    await _unidadTrabajo.Ocasion.Agregar(ocasion);
                }
                else 
                {
                    _unidadTrabajo.Ocasion.Actualizar(ocasion);
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(ocasion);
        }

        #region API

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Ocasion.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]

        public async Task<IActionResult>Delete(int id) 
        {
            var ocasionDb = await _unidadTrabajo.Ocasion.Obtener(id);
            if (ocasionDb == null) 
            {
                return Json(new { success = false, message = "Error al Borrar la Ocasion" });
            }
            _unidadTrabajo.Ocasion.Remover(ocasionDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Ocasion eliminada con Exito" });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Ocasion.ObtenerTodos();
            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim() && b.Id != id);
            }

            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }

        #endregion
    }
}
