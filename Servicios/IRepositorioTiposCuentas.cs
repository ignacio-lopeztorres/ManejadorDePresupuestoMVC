using ManejadorDePresupuestos.Models;

namespace ManejadorDePresupuestos.Servicios
{
    public interface IRepositorioTiposCuentas
    {
        Task Actualizar(TipoCuenta tipoCuenta);
        Task Borrar(int Id);
        Task Crear(TipoCuenta tipoCuenta);
        Task<bool> Existe(string nombre, int UsuarioID);
        Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId);
        Task<TipoCuenta> ObtenerPorId(int Id, int usuarioId);
    }
}
