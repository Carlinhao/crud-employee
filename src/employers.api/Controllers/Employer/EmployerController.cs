using employers.application.Interfaces.Empregado;
using employers.domain.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace employers.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployerController : ControllerBase
    {
        private readonly ILogger<EmployerController> _logger;

        public EmployerController(ILogger<EmployerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IGetEmployerUseCaseAsync getAsync)
        {
            _logger.LogDebug("Search all employer");
            var result = await getAsync.RunAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployerById(
            [FromServices] IGetEmployerByIdUseCaseAsync getEmployer,
            int id)
        {
            _logger.LogDebug("Search employer by id");
            var result = await getEmployer.RunAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromServices] IInsertEmployerUseCaseAsync useCaseAsync,
            [FromBody] EmployerRequest request)
        {
            _logger.LogDebug("Insert employer");
            var result = await useCaseAsync.RunAsync(request);

            return Ok(result);
        }
    }
}
