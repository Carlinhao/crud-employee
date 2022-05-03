using employers.application.Interfaces.UserAuth;
using employers.domain.Responses;
using employers.domain.UserAuth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace employers.api.Controllers.Auth
{
    /// <summary>
    /// Controller responsable by authentication
    /// </summary>
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Method reponsable by register a user login
        /// </summary>
        /// <param name="userAuth"></param>
        /// <param name="request"></param>
        /// <returns>returns a bearer token</returns>
        /// <response code="200">Return 200 when success</response>
        /// <response code="400">Return 400 error</response>
        [HttpPost("login")]
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

        /// <summary>
        /// Method reponsable by return refresh token
        /// </summary>
        /// <param name="userAuth"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Return 200 when success</response>
        /// <response code="400">Return 400 error</response>
        [HttpPost("refresh-token")]
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
