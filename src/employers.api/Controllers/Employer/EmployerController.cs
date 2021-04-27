using employers.application.Interfaces.Empregado;
using employers.application.Interfaces.ExportReport;
using employers.application.Notifications;
using employers.domain.Entities.Employee;
using employers.domain.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;

namespace employers.api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly ILogger<EmployerController> _logger;
        private readonly INotificationMessages _notificationMessages;

        public EmployerController(ILogger<EmployerController> logger,
                                  INotificationMessages notificationMessages)
        {
            _logger = logger;
            _notificationMessages = notificationMessages;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IGetEmployerUseCaseAsync getAsync)
        {
            _logger.LogDebug("Search all employer");
            var result = await getAsync.RunAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployerById(
            [FromServices] IGetEmployerByIdUseCaseAsync getEmployer,
            int id)
        {
            _logger.LogDebug("Search employer by id");
            var result = await getEmployer.RunAsync(id);

            if (_notificationMessages.HasNotification())
            {
                return BadRequest(_notificationMessages.Notications());
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromServices] IInsertEmployerUseCaseAsync useCaseAsync,
            [FromBody] EmployerRequest request)
        {
            _logger.LogDebug("Insert employer");
            var result = await useCaseAsync.RunAsync(request);

            if (_notificationMessages.HasNotification())
            {
                return BadRequest(_notificationMessages.Notications());
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] IDeleteEmployerUseCaseAsync delete,
            int id)
        {
            _logger.LogDebug("Delete employer");
            var result = await delete.RunAsync(id);

            if (_notificationMessages.HasNotification())
            {
                return BadRequest(_notificationMessages.Notications());
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromServices] IUpdateEmployerUseCaseAsync update,
            [FromBody] EmployeeEntity employerEntity)
        {
            _logger.LogDebug("Update employer");
            var result = await update.RunAsync(employerEntity);

            if (_notificationMessages.HasNotification())
            {
                return BadRequest(_notificationMessages.Notications());
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("csv")]
        public async Task<FileResult> ExportEmployerCsv(
            [FromServices] IExportCsvAsync exportCsvAsync)
        {
            _logger.LogDebug("Update employer");
            var createDate = DateTime.UtcNow;
            var exportData = await exportCsvAsync.ExportCsv();

            return File(Encoding.UTF8.GetBytes(exportData), "application/CSV", $"{createDate}_employer.csv");
        }
    }
}
