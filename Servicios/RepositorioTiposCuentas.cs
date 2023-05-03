using Dapper;
using ManejadorDePresupuestos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ManejadorDePresupuestos.Servicios
{
    public class RepositorioTiposCuentas : IRepositorioTiposCuentas
    {
        private readonly string connectionString;
        public RepositorioTiposCuentas(IConfiguration configuration) {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Crear(TipoCuenta tipoCuenta) {
            //uso de dapper
            using (var connection = new SqlConnection(connectionString))
            {
                var id = connection.QuerySingle<int>($@"INSERT INTO TiposCuentas (Nombre, UsuarioId, Orden) VALUES (@Nombre, @UsuarioId, 0);
                  SELECT SCOPE_IDENTITY();", tipoCuenta);  
            };
        }
    }
}
