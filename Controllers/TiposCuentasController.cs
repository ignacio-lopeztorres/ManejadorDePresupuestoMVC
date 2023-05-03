using ManejadorDePresupuestos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManejadorDePresupuestos.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly ILogger<TiposCuentasController> _logger;

        public TiposCuentasController(ILogger<TiposCuentasController> logger)
        {
            _logger = logger;
        }
        public IActionResult Crear() {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(TipoCuenta tipoCuenta) {
            if (!ModelState.IsValid) //permite verificar que Modelo sea correcto, si no es correcto al usuario se le enviara un mensaje de error
            {
                return View(tipoCuenta);
            }
            return View();
        }
    }
}
