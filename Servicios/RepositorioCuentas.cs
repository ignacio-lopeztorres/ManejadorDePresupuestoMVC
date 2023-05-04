using Dapper;
using ManejadorDePresupuestos.Models;
using Microsoft.Data.SqlClient;

namespace ManejadorDePresupuestos.Servicios
{
    public class RepositorioCuentas : IRepositorioCuentas
    {
        private readonly string _connectionString;

        public RepositorioCuentas(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(Cuenta cuenta)
        {
            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<int>(@"
                        INSERT INTO Cuentas (Nombre, TipoCuentaId, Descripcion, Balance)
                        VALUES (@Nombre, @TipoCuentaId, @Descripcion, @Balance);
                        SELECT SCOPE_IDENTITY();", cuenta);
            cuenta.Id = id;
        }
    }
}