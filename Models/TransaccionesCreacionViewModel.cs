using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejadorDePresupuestos.Models
{
    public class TransaccionesCreacionViewModel : Transaccion
    {
        public TransaccionesCreacionViewModel()
        { }

        public IEnumerable<SelectListItem> Cuentas { get; set; }
        public IEnumerable<SelectListItem> Categorias { get; set; }
    }
}