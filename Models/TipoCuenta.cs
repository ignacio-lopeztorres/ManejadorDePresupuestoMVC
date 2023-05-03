namespace ManejadorDePresupuestos.Models
{
    public class TipoCuenta
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }
    }
}
