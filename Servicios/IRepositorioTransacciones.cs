using ManejadorDePresupuestos.Models;

namespace ManejadorDePresupuestos.Servicios
{
    public interface IRepositorioTransacciones
    {
        Task Actualizar(Transaccion transaccion, decimal montoAnterior, int cuentaAnterior);

        Task Borrar(int id);

        Task Crear(Transaccion transaccion);

        Task<IEnumerable<Transaccion>> ObtenerPorCuentaId(ObtenerTransaccionesPorCuenta modelo);

        Task<Transaccion> ObtenerPorId(int id, int usuarioId);

        Task<IEnumerable<ResultadoObtenerPorMes>> ObtenerPorMes(int usuarioId, int anio);

        Task<IEnumerable<ResultadoObtenerPorSemana>> ObtenerPorSemana(ParametroObtenerTransaccionesPorUsuario modelo);

        Task<IEnumerable<Transaccion>> ObtenerPorUsuarioId(ParametroObtenerTransaccionesPorUsuario modelo);
    }
}