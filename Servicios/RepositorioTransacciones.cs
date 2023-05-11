using Dapper;
using ManejadorDePresupuestos.Models;
using Microsoft.Data.SqlClient;

namespace ManejadorDePresupuestos.Servicios
{
    public class RepositorioTransacciones : IRepositorioTransacciones
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

        public async Task<IEnumerable<Transaccion>> ObtenerPorCuentaId(ObtenerTransaccionesPorCuenta modelo)
        {
            using var connection = new SqlConnection(_connectionStrig);
            return await connection.QueryAsync<Transaccion>(@"
                SELECT t.Id, t.Monto, t.FechaTransaccion, c.Nombre as Categoria,
                cu.Nombre as Cuenta, c.TipoOperacionId
                FROM Transacciones t
                INNER JOIN Categorias c
                ON c.Id = t.CategoriaId
                INNER JOIN Cuentas cu
                ON cu.Id = t.CuentaId
                WHERE t.CuentaId = @CuentaId AND t.UsuarioId = @UsuarioId
                AND FechaTransaccion BETWEEN @FechaInicio AND @FechaFin", modelo);
        }

        public async Task Actualizar(Transaccion transaccion, decimal montoAnterior, int cuentaAnteriorId)
        {
            using var connection = new SqlConnection(_connectionStrig);
            await connection.ExecuteAsync("Transacciones_Actualizar", new { transaccion.Id, transaccion.FechaTransaccion, transaccion.Monto, transaccion.CategoriaId, transaccion.CuentaId, transaccion.Nota, montoAnterior, cuentaAnteriorId }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Transaccion> ObtenerPorId(int id, int usuarioId)
        {
            using var connection = new SqlConnection(_connectionStrig);
            return await connection.QueryFirstOrDefaultAsync<Transaccion>(@"
            SELECT Transacciones.*, cat.TipoOperacionId
            FROM Transacciones
            INNER JOIN Categorias cat
            ON cat.Id = Transacciones.CategoriaId
            WHERE Transacciones.Id = @Id AND Transacciones.UsuarioId = @UsuarioId", new { id, usuarioId });
        }

        public async Task Borrar(int id)
        {
            using var connection = new SqlConnection(_connectionStrig);
            await connection.ExecuteAsync("Transaccion_Borrar", new { id }, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}