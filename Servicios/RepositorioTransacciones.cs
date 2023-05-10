using Dapper;
using ManejadorDePresupuestos.Models;
using Microsoft.Data.SqlClient;

namespace ManejadorDePresupuestos.Servicios
{
    public class RepositorioTransacciones : IRepositorioCuenta
    {
        private readonly string _connectionStrig;

        public RepositorioTransacciones(IConfiguration configuration)
        {
            _connectionStrig = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(Transaccion transaccion)
        {
            using var connection = new SqlConnection(_connectionStrig);
            var id = await connection.QuerySingleAsync<int>("Transacciones_Insertar", new { transaccion.UsuarioId, transaccion.FechaTransaccion, transaccion.Monto, transaccion.CategoriaId, transaccion.CuentaId, transaccion.Nota }, commandType: System.Data.CommandType.StoredProcedure);

            transaccion.Id = id;
        }
    }
}