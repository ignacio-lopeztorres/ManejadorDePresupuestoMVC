using Dapper;
using ManejadorDePresupuestos.Models;
using ManejadorDePresupuestos.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejadorDePresupuestos.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly ILogger<TiposCuentasController> _logger;
        private readonly IRepositorioTiposCuentas repositorioTiposCuentas;
        private readonly IServicioUsuarios servicioUsuarios;

        public TiposCuentasController(ILogger<TiposCuentasController> logger,
            IRepositorioTiposCuentas repositorioTiposCuentas,
            IServicioUsuarios servicioUsuarios)
        {
            _logger = logger;
            this.repositorioTiposCuentas = repositorioTiposCuentas;
            this.servicioUsuarios = servicioUsuarios;
        }
        public async Task<IActionResult> Index() {
            var usuarioId = servicioUsuarios.ObtenerUsuarioId();
            var tiposCuentas = await repositorioTiposCuentas.Obtener(usuarioId);
            return View(tiposCuentas);
        }
        public IActionResult Crear() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoCuenta tipoCuenta) {
            if (!ModelState.IsValid) //permite verificar que Modelo sea correcto, si no es correcto al usuario se le enviara un mensaje de error
            {
                return View(tipoCuenta);
            }
            tipoCuenta.UsuarioId = servicioUsuarios.ObtenerUsuarioId();

            //verifica si ya esiste el tipo cuenta
            var yaExisteTipoCuenta = await repositorioTiposCuentas.Existe(tipoCuenta.Nombre, tipoCuenta.UsuarioId);

            if (yaExisteTipoCuenta)
            {
                ModelState.AddModelError(nameof(tipoCuenta.Nombre), $"El nombre {tipoCuenta.Nombre} ya existe");
                //retorna la vista con el tipo cuenta 
                return View(tipoCuenta);
            }
            await  repositorioTiposCuentas.Crear(tipoCuenta);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> VerificarExisteTipoCuenta(string nombre) {
            var UsuarioId = servicioUsuarios.ObtenerUsuarioId();

            //verifica si ya esiste el tipo cuenta
            var yaExisteTipoCuenta = await repositorioTiposCuentas.Existe(nombre, UsuarioId);

            if (yaExisteTipoCuenta)
            {
                return Json($"el nombre {nombre} ya existe");
            }

            return Json(true);
        }
    }
}
