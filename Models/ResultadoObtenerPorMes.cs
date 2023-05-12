namespace ManejadorDePresupuestos.Models
{
    public class ResultadoObtenerPorMes
    {
        public int Mes { get; set; }
        public DateTime FechaReferencia { get; set; }
        public decimal Monto { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Gastos { get; set; }
        public TipoOperacion TipoOperacionId { get; set; }
    }
}