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

        public async Task Crear(TipoCuenta tipoCuenta) {
            //uso de dapper
            using (var connection = new SqlConnection(connectionString))
            {
                var id = await connection.QuerySingleAsync<int>($@"INSERT INTO TiposCuentas (Nombre, UsuarioId, Orden) VALUES (@Nombre, @UsuarioId, 0);
                  SELECT SCOPE_IDENTITY();", tipoCuenta);  
            };
        }
        public async Task<bool> Existe(string nombre, int UsuarioID) {
            using var connection = new SqlConnection(connectionString);
            var existe = await connection.QueryFirstOrDefaultAsync<int>(
                            @"SELECT 1
                            FROM TiposCuentas
                            WHERE Nombre = @Nombre AND UsuarioId = @UsuarioId;",
                            new { nombre, UsuarioID});
            return existe == 1;
        }

        public async Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId) { 
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<TipoCuenta>(@"SELECT Id, Nombre, Orden
                                        FROM TiposCuentas
                                        WHERE UsuarioId = @UsuarioId", new {usuarioId });
        }
        public async Task Actualizar(TipoCuenta tipoCuenta) {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"UPDATE TiposCuentas
                                            SET Nombre = @Nombre 
                                            WHERE Id = @Id", tipoCuenta);
        }
        public async Task<TipoCuenta> ObtenerPorId(int Id, int usuarioId) { 
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<TipoCuenta>(@"
                                        SELECT Id, Nombre, Orden
                                        FROM TiposCuentas
                                        WHERE Id = @Id AND UsuarioId = @UsuarioId", new { Id, usuarioId});
                 
        }
    }
}
