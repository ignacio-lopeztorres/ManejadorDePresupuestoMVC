using System.ComponentModel.DataAnnotations;

namespace ManejadorDePresupuestos.Models
{
    public class TipoCuenta
    {
        public string Id { get; set; }
        [Required] //esta anotacion sirve para que el campo no se envie vacio
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }
    }
}
