using ManejadorDePresupuestos.Models;

namespace ManejadorDePresupuestos.Servicios
{
    public interface IServicioReportes
    {
        Task<IEnumerable<ResultadoObtenerPorSemana>> ObtenerReporteSemanal(int usuarioId, int mes, int anio, dynamic ViewBag);

        Task<ReporteTransaccionesDetalladas> ObtenerReporteTransaccionesDetalladas(int usuarioId, int mes, int abio, dynamic ViewBag);

        Task<ReporteTransaccionesDetalladas> ObtenerReporteTransaccionesDetalladasPorCuenta(int usuarioId, int cuentaId, int mes, int anio, dynamic ViewBag);
    }
}