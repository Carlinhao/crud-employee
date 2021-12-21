using employers.application.Interfaces.Occupation;
using employers.domain.Requests;
using employers.domain.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace employers.api.Controllers.Occupation
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<ResultResponse>> InsertAsync([FromServices] IInsertOccupationUseCaseAsync updateOccupation,
                                                                    [FromBody] OccupationRequest request)
        {
            var result = await updateOccupation.RunAsync(request);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ResultResponse>> UpdateAsync([FromServices] IUpdateOccupationUseCaseAsync updateOccupation, 
                                                                    [FromBody] OccupationUpdateRequest request)
        {
            var result = await updateOccupation.RunAsync(request);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync([FromServices] IGetOccupationUseCaseAsync useCaseAsync)
        {
            return Ok(await useCaseAsync.RunAsync());
        }
    }
}
