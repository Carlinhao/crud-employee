using System.Threading.Tasks;
using employers.application.Interfaces.UserAuth;
using employers.domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employers.api.Controllers.CreateUser
{
    /// <summary>
    /// Controller responsable by create a user.
    /// </summary>
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CreateUserController : ControllerBase
    {
        private readonly ICreateUserUseCaseAsync _createUserUseCaseAsync;

        public CreateUserController(ICreateUserUseCaseAsync createUserUseCaseAsync)
        {
            _createUserUseCaseAsync = createUserUseCaseAsync;
        }

        /// <summary>
        /// Method responsable by insert a new user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Returns a number of user created</returns>
        /// <response code="200" ></response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> InserUser([FromBody] CreateUserRequest request)
        {
            return Ok(await _createUserUseCaseAsync.RunAsync(request));
        }
    }
}
