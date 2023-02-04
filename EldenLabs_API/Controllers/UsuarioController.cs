using BLL;
using DAL;
using DAL.Entities;
using EldenLabs_API.Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EldenLabs_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UsuarioController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Usuario usuario)
        {
            AdministracionUsuarios administracionUsuarios = new AdministracionUsuarios(_applicationDbContext);
            bool acceso = administracionUsuarios.Login(usuario);

            if (acceso)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
