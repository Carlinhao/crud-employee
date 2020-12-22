using employers.application.Interfaces.Empregado;
using employers.domain.Entities.Employer;
using employers.domain.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace employers.api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] IDeleteEmployerUseCaseAsync delete,
            int id)
        {
            _logger.LogDebug("Delete employer");
            var result = await delete.RunAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromServices] IUpdateEmployerUseCaseAsync update,
            [FromBody] EmployerEntity employerEntity)
        {
            _logger.LogDebug("Update employer");
            var result = await update.RunAsync(employerEntity);
            return Ok(result);
        }
    }
}
