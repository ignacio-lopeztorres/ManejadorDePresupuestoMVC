using System.Security.Claims;

namespace ManejadorDePresupuestos.Servicios
{
    public class ServicioUsuarios : IServicioUsuarios
    {
        private readonly HttpContext _httpContext;

        public ServicioUsuarios(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public int ObtenerUsuarioId()
        {
            if (_httpContext.User.Identity.IsAuthenticated)
            {
                var idClaim = _httpContext.User.Claims
                    .Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
                var id = int.Parse(idClaim.Value);
                return id;
            }
            else
            {
                throw new ApplicationException("El Usuario no esta autenticado");
            }
        }
    }
}