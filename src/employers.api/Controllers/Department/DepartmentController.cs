using System.Threading.Tasks;
using employers.application.Interfaces.Departament;
using employers.application.Interfaces.UseCases.Departament;
using employers.application.Notifications;
using employers.domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace employers.api.Controllers
{
    /// <summary>
    /// API responsible for department management.
    /// </summary>
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/department")]
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

        /// <summary>
        /// Method responsible that return all Department.
        /// </summary>
        /// <param name="getAsync"></param>
        /// <returns>Return a list of the department.</returns>
        /// <response code="200">Return all departmen</response>
        /// <response code="204">Return empty payload</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromServices] IGetDepartamentUseCaseAsync getAsync)
        {
            _logger.LogInformation("Find all department");
            var result = await getAsync.RunAsync();
            if (result == null) 
                return NoContent();

            return Ok(result);
        }

        /// <summary>
        /// Get a department by Id
        /// </summary>
        /// <param name="getAsync"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Return a department by id.</response>
        /// <response code="400">Return when return an error.</response>
        /// <response code="404">Return when not found a department.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromServices] IGetDepartamentByIdUseCaseAsync getAsync,
            int id)
        {
            var result = await getAsync.RunAsync(id);
            if (result == null)
                return NotFound(result);

            if (_notificationMessages.HasNotification())
            {
                return BadRequest(_notificationMessages.Notications());
            }
            _logger.LogInformation("Find department by id");
            return Ok(result);
        }

        /// <summary>
        /// Insert a new department.
        /// </summary>
        /// <param name="postAsync"></param>
        /// <param name="departmentRequest"></param>
        /// <returns></returns>
        /// <response code="201">Return number of department created</response>
        /// <response code="400">Return when return an error message.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

            return Created(uri: "api/v1/department", result);
        }
    }
}
