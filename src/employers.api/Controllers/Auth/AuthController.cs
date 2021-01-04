using employers.application.Interfaces.UserAuth;
using employers.domain.UserAuth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace employers.api.Controllers.Auth
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(
            [FromServices] IUserAuthUseCaseAsync userAuth,
            [FromBody] UserInfoRequest request)
        {
            if (request == null)
                return BadRequest("Invalid login!!!");

            var result = await userAuth.RunAsync(request);

            if (result == null)
                return Unauthorized();

            return Ok(result);
        }
    }
}
