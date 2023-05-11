namespace ManejadorDePresupuestos.Models
{
    public class ReporteSemanalViewModel
    {
        public decimal Ingresos => TransaccionesPorSemanas.Sum(x => x.Ingresos);
        public decimal Gastos => TransaccionesPorSemanas.Sum(x => x.Gastos);
        public decimal Total => Ingresos - Gastos;
        public DateTime FechaReferencia { get; set; }
        public IEnumerable<ResultadoObtenerPorSemana> TransaccionesPorSemanas { get; set; }
    }
}