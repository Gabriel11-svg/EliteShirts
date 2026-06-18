using Microsoft.AspNetCore.Mvc;
using EliteShirts.API.Data;
using EliteShirts.API.Models;

namespace EliteShirts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(Usuario usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(x =>
                x.Email == usuario.Email &&
                x.Password == usuario.Password);

            if (user == null)
            {
                return Unauthorized("Credenciales incorrectas");
            }

            return Ok(new
            {
                mensaje = "Login exitoso"
            });
        }
    }
}