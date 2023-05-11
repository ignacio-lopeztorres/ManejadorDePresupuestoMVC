namespace ManejadorDePresupuestos.Models
{
    public class ResultadoObtenerPorSemana
    {
        public int Semana { get; set; }
        public decimal Monto { get; set;}
        public TipoOperacion TipoOperacionId { get; set;}
    }
}
