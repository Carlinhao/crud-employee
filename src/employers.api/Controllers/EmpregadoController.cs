using employers.application.Interfaces.Empregado;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace employers.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpregadoController : ControllerBase
    {
        private readonly ILogger<EmpregadoController> _logger;

        public EmpregadoController(ILogger<EmpregadoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IGetEmployerUseCaseAsync getAsync)
        {
            _logger.LogDebug("Buscando todos os Empregados");
            var result = await getAsync.RunAsync();

            return Ok(result);
        }
    }
}
