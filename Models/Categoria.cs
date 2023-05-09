using System.ComponentModel.DataAnnotations;

namespace ManejadorDePresupuestos.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "No puede ser mmayor a {1} caracteres")]
        public string Nombre { get; set; }

        public TipoOperacion tipoOperacionId { get; set; }

        public int UsuarioId { get; set; }
    }
}