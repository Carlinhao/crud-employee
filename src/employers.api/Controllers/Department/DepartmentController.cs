using employers.application.Interfaces.Departament;
using employers.application.Interfaces.UseCases.Departament;
using employers.application.Notifications;
using employers.domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace employers.api.Controllers
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly INotificationMessages _notificationMessages;
        public DepartmentController(ILogger<DepartmentController> logger, 
            INotificationMessages notificationMessages)
        {
            _logger = logger;
            _notificationMessages = notificationMessages;
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
            var result = await getAsync.RunAsync(id);

            if(_notificationMessages.HasNotification())
            {
                return BadRequest(_notificationMessages.Notications());
            }
            _logger.LogDebug("Buscando Departamentos por Id");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromServices] IInsertDepartmentUseCaseAsync postAsync,
            [FromBody] DepartmentRequest departmentRequest)
        {
            _logger.LogDebug("Insert department");
            var result = await postAsync.RunAsync(departmentRequest);

            if (_notificationMessages.HasNotification())
            {
                return BadRequest(_notificationMessages.Notications());
            }

            return Ok(result);
        }
    }
}
