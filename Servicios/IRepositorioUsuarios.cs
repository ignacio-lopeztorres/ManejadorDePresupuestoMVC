using ManejadorDePresupuestos.Models;

namespace ManejadorDePresupuestos.Servicios
{
    public interface IRepositorioUsuarios
    {
        Task<Usuario> BuscarUsuarioPorEmail(string EmailNormalizado);

        Task<int> CrearUsuario(Usuario usuario);
    }
}