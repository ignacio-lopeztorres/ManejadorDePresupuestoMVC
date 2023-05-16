using Dapper;
using ManejadorDePresupuestos.Models;
using Microsoft.Data.SqlClient;

namespace ManejadorDePresupuestos.Servicios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly string _ConnectionString;

        public RepositorioUsuarios(IConfiguration configuration)
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> CrearUsuario(Usuario usuario)
        {
            //usuario.EmailNormalizado = usuario.Email.ToUpper();
            using var connection = new SqlConnection(_ConnectionString);
            var id = await connection.QuerySingleAsync<int>(@"
                INSERT INTO Usuarios (Email, EmailNormalizado, PasswordHash)
                VALUES (@Email, @EmailNormalizado, @PasswordHash)", usuario);
            return id;
        }

        public async Task<Usuario> BuscarUsuarioPorEmail(string EmailNormalizado)
        {
            using var connection = new SqlConnection(_ConnectionString);
            return await connection.QuerySingleOrDefaultAsync<Usuario>(@"
                    SELECT * FROM Usuarios
                    WHERE EmailNormalizado = @EmailNormalizado", new { EmailNormalizado });
        }
    }
}