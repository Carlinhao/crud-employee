using employers.application.Interfaces.Departament;
using employers.application.Interfaces.UseCases.Departament;
using employers.domain.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace employers.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IGetDepartamentUseCaseAsync getAsync)
        {
            _logger.LogDebug("Buscando todos os Departamentos");
            var result = await getAsync.RunAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromServices] IGetDepartamentByIdUseCaseAsync getAsync,
            int id)
        {
            _logger.LogDebug("Buscando Departamentos por Id");
            var result = await getAsync.RunAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromServices] IInsertDepartmentUseCaseAsync postAsync,
            [FromBody] DepartmentRequest departmentRequest)
        {
            _logger.LogDebug("Insert department");
            var result = await postAsync.RunAsync(departmentRequest);
            return Ok(result);
        }
    }
}
