using employers.application.Interfaces.UserAuth;
using employers.domain.Responses;
using employers.domain.UserAuth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace employers.api.Controllers.Auth
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("v1/login")]
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

        [HttpPost("v1/refresh-token")]
        public async Task<IActionResult> RefreshToken(
            [FromServices] IUserAuthRefreshTokenUseCaseAsync userAuth,
            [FromBody] TokenResponse request)
        {
            if (request == null)
                return BadRequest("Invalid login!!!");

            var result = await userAuth.RunAsync(request);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}
