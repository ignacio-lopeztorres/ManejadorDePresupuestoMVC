using ManejadorDePresupuestos.Models;
using ManejadorDePresupuestos.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ManejadorDePresupuestos.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IRepositorioCategorias repositorioCategorias;
        private readonly IServicioUsuarios servicioUsuarios;

        public CategoriaController(IRepositorioCategorias repositorioCategorias,
            IServicioUsuarios servicioUsuarios)
        {
            this.repositorioCategorias = repositorioCategorias;
            this.servicioUsuarios = servicioUsuarios;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return View(categoria);
            }
            var usuarioId = servicioUsuarios.ObtenerUsuarioId();
            categoria.UsuarioId = usuarioId;
            await repositorioCategorias.Crear(categoria);
            return RedirectToAction("Index");
        }
    }
}