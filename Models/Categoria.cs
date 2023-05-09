using System.ComponentModel.DataAnnotations;

namespace ManejadorDePresupuestos.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "No puede ser mmayor a {1} caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Tipo Operacion")]
        public TipoOperacion TipoOperacionId { get; set; }

        public int TipoOperacionIdval => Convert.ToInt32(TipoOperacionId);

        public int UsuarioId { get; set; }
    }
}