using ManejadorDePresupuestos.Models;

namespace ManejadorDePresupuestos.Servicios
{
    public interface IRepositorioCuenta
    {
        Task Crear(Transaccion transaccion);
    }
}