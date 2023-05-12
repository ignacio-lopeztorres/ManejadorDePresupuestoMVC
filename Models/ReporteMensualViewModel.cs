namespace ManejadorDePresupuestos.Models
{
    public class ReporteMensualViewModel
    {
        public decimal Ingresos => TransaccionesPorMes.Sum(x => x.Ingresos);
        public decimal Gastos => TransaccionesPorMes.Sum(x => x.Gastos);
        public decimal Total => Ingresos - Gastos;
        public DateTime FechaReferencia { get; set; }
        public IEnumerable<ResultadoObtenerPorMes> TransaccionesPorMes { get; set; }
        public int Anio { get; set; }
    }
}