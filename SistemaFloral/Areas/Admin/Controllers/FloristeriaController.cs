using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaFloral.AccesoDatos.Repositorio.IRepositorio;
using SistemaFloral.Modelos.ViewModels;
using SistemaFloral.Utilidades;
using System.Security.Claims;

namespace SistemaFloral.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Admin)]
    public class FloristeriaController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;

        public FloristeriaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;            
        }

        public async Task<IActionResult> Upsert() 
        {
            FloristeriaVM floristeriaVM = new FloristeriaVM()
            {
                Floristeria = new Modelos.Modelos.Floristeria(),
                BodegaLista = _unidadTrabajo.Inventario.ObtenerTodosDropdownLista("Bodega")
            };
            floristeriaVM.Floristeria = await _unidadTrabajo.Floristeria.ObtenerPrimero();

            if (floristeriaVM.Floristeria == null) 
            {
                floristeriaVM.Floristeria = new Modelos.Modelos.Floristeria();
            }

            return View(floristeriaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Upsert(FloristeriaVM floristeriaVM) 
        {
            if (ModelState.IsValid)
            {
                TempData[DS.Exitosa] = "Floristeria Grabada Exitosamente";
                var claimIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

                if (floristeriaVM.Floristeria.Id == 0) //Crear Floristeria
                {
                    floristeriaVM.Floristeria.CreadoPorId = claim.Value;
                    floristeriaVM.Floristeria.ActualizadoPorId = claim.Value;
                    floristeriaVM.Floristeria.FechaCreacion = DateTime.Now;
                    floristeriaVM.Floristeria.FechaActualizacion = DateTime.Now;
                    await _unidadTrabajo.Floristeria.Agregar(floristeriaVM.Floristeria);
                }
                else // Act5ualizar Floristeria
                {
                    floristeriaVM.Floristeria.ActualizadoPorId = claim.Value;
                    floristeriaVM.Floristeria.FechaActualizacion = DateTime.Now;
                    _unidadTrabajo.Floristeria.Actualizar(floristeriaVM.Floristeria);
                }

                await _unidadTrabajo.Guardar();
                return RedirectToAction("Index","Home", new { area="Inventario"});
            }

            TempData[DS.Error] = "Error al grabar Floristeria";
            return View(floristeriaVM);
        }
    }
}
