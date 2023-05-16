using ManejadorDePresupuestos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ManejadorDePresupuestos.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<Usuario> userManager;

        public UsuariosController(UserManager<Usuario> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            var usuario = new Usuario() { Email = modelo.Email };

            var resultado = await userManager.CreateAsync(usuario, password: modelo.Password);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Transacciones");
            }
            else
            {
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(modelo);
            }
        }
    }
}