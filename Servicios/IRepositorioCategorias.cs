using ManejadorDePresupuestos.Models;

namespace ManejadorDePresupuestos.Servicios
{
    public interface IRepositorioCategorias
    {
        Task Actualizar(Categoria categoria);

        Task Borrar(int id);
        Task<int> Contar(int usuarioId);
        Task Crear(Categoria categoria);

        Task<IEnumerable<Categoria>> Obtener(int usuarioId, PaginacionViewModel paginacion);

        Task<IEnumerable<Categoria>> Obtener(int usuarioId, TipoOperacion tipoOperacionId);

        Task<Categoria> ObtenerPorId(int id, int usuarioId);
    }
}