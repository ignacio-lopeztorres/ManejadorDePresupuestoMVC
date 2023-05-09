using ManejadorDePresupuestos.Models;

namespace ManejadorDePresupuestos.Servicios
{
    public interface IRepositorioCategorias
    {
        Task Crear(Categoria categoria);
    }
}