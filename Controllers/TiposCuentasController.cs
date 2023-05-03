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
            return View();
        }
    }
}
