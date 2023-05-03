using Dapper;
using ManejadorDePresupuestos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejadorDePresupuestos.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly ILogger<TiposCuentasController> _logger;
        private readonly string connectionString;

        public TiposCuentasController(ILogger<TiposCuentasController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IActionResult Crear() {

            //uso de dapper
            using (var connection = new SqlConnection(connectionString)) {
                var query = connection.Query("SELECT 1").FirstOrDefault();
            };
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
