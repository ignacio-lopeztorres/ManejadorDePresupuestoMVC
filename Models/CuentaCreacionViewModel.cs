using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejadorDePresupuestos.Models
{
    public class CuentaCreacionViewModel : Cuenta
    {
        public IEnumerable<SelectListItem> TiposCuentas { get; set; }
    }
}