using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Asp.Versioning;
using employers.application.Interfaces.Empregado;
using employers.application.Interfaces.ExportReport;
using employers.application.Notifications;
using employers.domain.Entities.Employee;
using employers.domain.Requests;
using employers.domain.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace employers.api.Controllers.Employer;

/// <summary>
/// Controller responsable by employers.
/// </summary>
[Authorize]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/employer")]
[ApiController]
public class EmployerController(ILogger<EmployerController> logger,
                                INotificationMessages notificationMessages) : ControllerBase
{
    /// <summary>
    /// Return all employers or empty.
    /// </summary>
    /// <param name="getAsync"></param>
    /// <returns>return all employers</returns>
    /// <response code="200">Return all employers</response>
    /// <response code="204">Return empty payload</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EmployeeEntity>),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll([FromServices] IGetEmployerUseCaseAsync getAsync)
    {
        logger.LogDebug("Search all employer");
        var result = await getAsync.RunAsync();

        if (result == null)
            return NoContent();

        return Ok(result);
    }

    /// <summary>
    /// Return an employer by id.
    /// </summary>
    /// <param name="getEmployer"></param>
    /// <param name="id"></param>
    /// <returns>Return an employer by id.</returns>
    /// <response code="200">Return all employers</response>
    /// <response code="400">When return error</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(EmployeeEntity),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetEmployerById(
        [FromServices] IGetEmployerByIdUseCaseAsync getEmployer,
        int id)
    {
        logger.LogDebug("Search employer by id");
        var result = await getEmployer.RunAsync(id);

        if (result is null)
            return NotFound();

        if (notificationMessages.HasNotification())
        {
            return BadRequest(notificationMessages.Notications());
        }

        return Ok(result);
    }

    /// <summary>
    /// Save an employer in database.
    /// </summary>
    /// <param name="useCaseAsync"></param>
    /// <param name="request"></param>
    /// <returns>Return quantity register save</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int),StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostAsync(
        [FromServices] IInsertEmployerUseCaseAsync useCaseAsync,
        [FromBody] EmployerRequest request)
    {
        logger.LogDebug("Insert employer");
        var result = await useCaseAsync.RunAsync(request);

        if (notificationMessages.HasNotification())
        {
            return BadRequest(notificationMessages.Notications());
        }

        return Ok(result);
    }

    /// <summary>
    /// Delete an register
    /// </summary>
    /// <param name="delete"></param>
    /// <param name="id"></param>
    /// <returns>Return quantity register deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(int),StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync(
        [FromServices] IDeleteEmployerUseCaseAsync delete,
        int id)
    {
        logger.LogDebug("Delete employer");
        var result = await delete.RunAsync(id);

        if (notificationMessages.HasNotification())
        {
            return BadRequest(notificationMessages.Notications());
        }

        return Ok(result);
    }

    /// <summary>
    /// Return an response with register updated
    /// </summary>
    /// <param name="update"></param>
    /// <param name="employerEntity"></param>
    /// <returns>Return an response with register updated</returns>
    [HttpPut]
    [ProducesResponseType(typeof(ResultResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync(
        [FromServices] IUpdateEmployerUseCaseAsync update,
        [FromBody] EmployeeEntity employerEntity)
    {
        logger.LogDebug("Update employer");
        var result = await update.RunAsync(employerEntity);

        if (notificationMessages.HasNotification())
        {
            return BadRequest(notificationMessages.Notications());
        }

        return Ok(result);
    }

    /// <summary>
    /// Export all register in file csv
    /// </summary>
    /// <param name="exportCsvAsync"></param>
    /// <returns>Retunr file csv</returns>
    [HttpGet]
    [Route("csv")]
    [ProducesResponseType(typeof(FileResult),StatusCodes.Status200OK)]
    public async Task<FileResult> ExportEmployerCsv(
        [FromServices] IExportCsvAsync exportCsvAsync)
    {
        logger.LogDebug("Update employer");
        var createDate = DateTime.UtcNow;
        var exportData = await exportCsvAsync.ExportCsv();

        return File(Encoding.UTF8.GetBytes(exportData), "application/CSV", $"{createDate}_employer.csv");
    }
}
