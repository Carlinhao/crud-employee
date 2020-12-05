using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace employers.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpregadoController : ControllerBase
    {
        private readonly ILogger<EmpregadoController> _logger;

        public EmpregadoController(ILogger<EmpregadoController> logger)
        {
            _logger = logger;
        }
    }
}
