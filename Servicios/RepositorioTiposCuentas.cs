using Dapper;
using ManejadorDePresupuestos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ManejadorDePresupuestos.Servicios
{
    public class RepositorioTiposCuentas : IRepositorioTiposCuentas
    {
        private readonly string connectionString;

        public RepositorioTiposCuentas(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(TipoCuenta tipoCuenta)
        {
            //uso de dapper
            using (var connection = new SqlConnection(connectionString))
            {
                var id = await connection.QuerySingleAsync<int>
                                        ("TiposCuenta_Insertar",
                                        new { tipoCuenta.UsuarioId, nombre = tipoCuenta.Nombre  },
                                        commandType: System.Data.CommandType.StoredProcedure); 
                tipoCuenta.Id = id;
            };
        }

        public async Task<bool> Existe(string nombre, int UsuarioID)
        {
            using var connection = new SqlConnection(connectionString);
            var existe = await connection.QueryFirstOrDefaultAsync<int>(
                            @"SELECT 1
                            FROM TiposCuentas
                            WHERE Nombre = @Nombre AND UsuarioId = @UsuarioId;",
                            new { nombre, UsuarioID });
            return existe == 1;
        }

        public async Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<TipoCuenta>(@"SELECT Id, Nombre, Orden
                                        FROM TiposCuentas
                                        WHERE UsuarioId = @UsuarioId
                                        ORDER BY Orden", new { usuarioId });
        }

        public async Task Actualizar(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"UPDATE TiposCuentas
                                            SET Nombre = @Nombre
                                            WHERE Id = @Id", tipoCuenta);
        }

        public async Task<TipoCuenta> ObtenerPorId(int Id, int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<TipoCuenta>(@"
                                        SELECT Id, Nombre, Orden
                                        FROM TiposCuentas
                                        WHERE Id = @Id AND UsuarioId = @UsuarioId", new { Id, usuarioId });
        }

        public async Task Borrar(int Id)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("DELETE TiposCuentas WHERE Id = @Id", new { Id });
        }

        public async Task Ordenar(IEnumerable<TipoCuenta> tipoCuentasOrdenado)
        {
            var query = "UPDATE TiposCuentas SET Orden = @Orden WHERE Id = @Id;";
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(query, tipoCuentasOrdenado);
        }
    }
}