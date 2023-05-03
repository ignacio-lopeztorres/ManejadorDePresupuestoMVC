using System.ComponentModel.DataAnnotations;

namespace ManejadorDePresupuestos.Models
{
    public class TipoCuenta
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")] //esta anotacion sirve para que el campo no se envie vacio
        [StringLength(maximumLength:50, MinimumLength = 3, ErrorMessage = "La logitud del campo {0} debe estar entre {2} y {1}")]
        [Display(Name = "Nombre del tipo cuenta")]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }
    }
}
