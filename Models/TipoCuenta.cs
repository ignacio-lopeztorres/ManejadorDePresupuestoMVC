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

        /*Pruebas de otras validaciones por defecto*/
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El Campo debe de ser un correo electrónico válido")]
        public string Email { get; set; }
        [Range(minimum:18, maximum: 120, ErrorMessage = "El valor debe estar entre {1} y {2}")]
        public int Edad { get; set; }
        [Url(ErrorMessage = "El campo debe de ser una URL válida")]
        public string URL { get; set; }
        [CreditCard(ErrorMessage = "La targeta de credito no es válida")]
        public string CreditCard { get; set; }
    }
}
