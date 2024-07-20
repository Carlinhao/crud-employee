using System.Threading.Tasks;
using Asp.Versioning;
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
    [Route("api/v{version:apiVersion}/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserUseCaseAsync _createUserUseCaseAsync;

        public UserController(ICreateUserUseCaseAsync createUserUseCaseAsync)
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
        [ProducesResponseType(typeof(HttpResponse) ,StatusCodes.Status201Created)]
        public async Task<IActionResult> InserUser([FromBody] CreateUserRequest request)
        {
            await _createUserUseCaseAsync.RunAsync(request);
            return Created("",default);
        }
    }
}
