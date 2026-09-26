using System.Collections.Generic;
using System.Threading.Tasks;
using Asp.Versioning;
using employers.application.Interfaces.Departament;
using employers.application.Interfaces.UseCases.Departament;
using employers.application.Notifications;
using employers.domain.Entities;
using employers.domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace employers.api.Controllers.Department;

/// <summary>
/// API responsible for department management.
/// </summary>
[Authorize]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/department")]
[ApiController]
public class DepartmentController(ILogger<DepartmentController> logger,
                                  INotificationMessages notificationMessages) : ControllerBase
{

    /// <summary>
    /// Method responsible that return all Department.
    /// </summary>
    /// <param name="getAsync"></param>
    /// <returns>Return a list of the department.</returns>
    /// <response code="200">Return all departmen</response>
    /// <response code="204">Return empty payload</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DepartmentEntity>),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(HttpResponse),StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll([FromServices] IGetDepartamentUseCaseAsync getAsync)
    {
        logger.LogInformation("Find all department");
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
    [ProducesResponseType(typeof(DepartmentEntity),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Notification),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetDepartamentByIdUseCaseAsync getAsync,
        int id)
    {
        var result = await getAsync.RunAsync(id);
        if (result == null)
            return NotFound(result);

        if (notificationMessages.HasNotification())
        {
            return BadRequest(notificationMessages.Notications());
        }
        logger.LogInformation("Find department by id");
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
    [ProducesResponseType(typeof(int),StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostAsync(
        [FromServices] IInsertDepartmentUseCaseAsync postAsync,
        [FromBody] DepartmentRequest departmentRequest)
    {
        logger.LogDebug("Insert department");
        var result = await postAsync.RunAsync(departmentRequest);

        if (notificationMessages.HasNotification())
        {
            return BadRequest(notificationMessages.Notications());
        }

        return Created(uri: "api/v1/department", result);
    }
}
