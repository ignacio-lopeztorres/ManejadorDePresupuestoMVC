using ManejadorDePresupuestos.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace ManejadorDePresupuestos.Models
{
    public class TipoCuenta
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")] //esta anotacion sirve para que el campo no se envie vacio
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }
    }
}
