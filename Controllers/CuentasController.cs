using ManejadorDePresupuestos.Models;
using ManejadorDePresupuestos.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejadorDePresupuestos.Controllers
{
    public class CuentasController : Controller
    {
        private readonly IRepositorioTiposCuentas repositorioTiposCuentas;
        private readonly IServicioUsuarios servicioUsuarios;

        public CuentasController(
            IRepositorioTiposCuentas repositorioTiposCuentas,
            IServicioUsuarios servicioUsuarios
            )
        {
            this.repositorioTiposCuentas = repositorioTiposCuentas;
            this.servicioUsuarios = servicioUsuarios;
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var usuarioId = servicioUsuarios.ObtenerUsuarioId();
            var tiposCuentas = await repositorioTiposCuentas.Obtener(usuarioId);
            var modelo = new CuentaCreacionViewModel();
            //modelo.TipoCuentaId
            modelo.TiposCuentas = tiposCuentas.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
            return View(modelo);
        }
    }
}