using Dapper;
using ManejadorDePresupuestos.Models;
using Microsoft.Data.SqlClient;

namespace ManejadorDePresupuestos.Servicios
{
    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly string _connectionString;

        public RepositorioCategorias(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(Categoria categoria)
        {
            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<int>(@"
                INSERT INTO Categorias (Nombre, TipoOperacionId, UsuarioId)
                VALUES (@Nombre, @TipoOperacionIdVal, @UsuarioId);
                SELECT SCOPE_IDENTITY();", categoria);
            categoria.Id = id;
        }

        public async Task<IEnumerable<Categoria>> Obtener(int usuarioId, PaginacionViewModel paginacion)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Categoria>(
                @$"SELECT *
                    FROM Categorias
                    WHERE UsuarioId = @UsuarioId
                    ORDER BY Nombre
                    OFFSET {paginacion.RecordsASaltar} ROWS FETCH NEXT {paginacion.RecordsPorPagina}
                    ROWS ONLY", new { usuarioId });
        }

        public async Task<IEnumerable<Categoria>> Obtener(int usuarioId, TipoOperacion tipoOperacionId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Categoria>(
                @"SELECT *
                FROM Categorias
                WHERE UsuarioId = @UsuarioId AND TipoOperacionId = @TipoOperacionId", new { usuarioId, tipoOperacionId });
        }

        public async Task<Categoria> ObtenerPorId(int id, int usuarioId)
        {
            using var con = new SqlConnection(_connectionString);
            return await con.QueryFirstOrDefaultAsync<Categoria>(@"SELECT * FROM Categorias WHERE Id = @Id AND UsuarioId = @usuarioId", new { id, usuarioId });
        }

        public async Task Actualizar(Categoria categoria)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(@"UPDATE Categorias SET Nombre = @Nombre, TipoOperacionId = @TipoOperacionId WHERE Id = @Id", categoria);
        }

        public async Task Borrar(int id)
        {
            using var con = new SqlConnection(_connectionString);
            await con.ExecuteAsync(@"DELETE Categorias WHERE Id = @Id", new { id });
        }
    }
}