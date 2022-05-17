using employers.application.Interfaces.Occupation;
using employers.domain.Requests;
using employers.domain.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace employers.api.Controllers.Occupation
{
    /// <summary>
    /// Controller responsable by occupations.
    /// </summary>
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/occupation")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        /// <summary>
        /// Save occupation in database.
        /// </summary>
        /// <param name="updateOccupation"></param>
        /// <param name="request"></param>
        /// <returns>Return quantity element save</returns>
        /// <response code="201">Created</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ResultResponse>> InsertAsync([FromServices] IInsertOccupationUseCaseAsync updateOccupation,
                                                                    [FromBody] OccupationRequest request)
        {
            var result = await updateOccupation.RunAsync(request);

            return Created("api/v1/occupation", result);
        }

        /// <summary>
        /// Update a register.
        /// </summary>
        /// <param name="updateOccupation"></param>
        /// <param name="request"></param>
        /// <returns>Return response with success</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResultResponse>> UpdateAsync([FromServices] IUpdateOccupationUseCaseAsync updateOccupation, 
                                                                    [FromBody] OccupationUpdateRequest request)
        {
            var result = await updateOccupation.RunAsync(request);

            return Ok(result);
        }

        /// <summary>
        /// Returns all occupation.
        /// </summary>
        /// <param name="useCaseAsync"></param>
        /// <returns>Returns all occupation</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> GetAllAsync([FromServices] IGetOccupationUseCaseAsync useCaseAsync)
        {
            var result = await useCaseAsync.RunAsync();
            if (result is null )
                return NotFound();
            
            return Ok(result);
        }
    }
}
