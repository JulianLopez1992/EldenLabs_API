using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EldenLabs_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetriaController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TelemetriaController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // GET: api/<TelemetriaController>
        [HttpGet]
        public IActionResult Get(DateTime? FechaInicial = null, DateTime? FechaFinal = null)
        {
            AdministracionTelemetria administracionTelemetria = new AdministracionTelemetria(_applicationDbContext);
            var telemetrias = administracionTelemetria.ConsultarTelemetrias(FechaInicial, FechaFinal);
            return Ok(telemetrias);
        }

        // POST api/<TelemetriaController>
        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            AdministracionTelemetria administracionTelemetria = new AdministracionTelemetria(_applicationDbContext);
            administracionTelemetria.CargarTelemetriaCSV(file);
            return Ok();
        }

        // PUT api/<TelemetriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

    }
}
