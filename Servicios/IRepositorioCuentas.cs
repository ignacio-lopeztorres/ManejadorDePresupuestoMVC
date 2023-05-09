using ManejadorDePresupuestos.Models;

namespace ManejadorDePresupuestos.Servicios
{
    public interface IRepositorioCuentas
    {
        Task Actualizar(CuentaCreacionViewModel cuenta);
        Task Borrar(int Id);
        Task<IEnumerable<Cuenta>> Buscar(int usuarioId);

        Task Crear(Cuenta cuenta);

        Task<Cuenta> ObtenerPorId(int Id, int usuarioId);
    }
}