using employers.application.Interfaces.Occupation;
using employers.domain.Requests;
using employers.domain.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace employers.api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ResultResponse>> InsertAsync([FromServices] IUpdateOccupationUseCaseAsync updateOccupation, 
                                                      [FromBody] OccupationUpdateRequest request)
        {
            var result = await updateOccupation.RunAsync(request);

            return Ok(result);
        }
    }
}
