using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace employers.domain.Token
{
    public interface ITokenGenerate
    {
        Task<string> GenerateAccessToken(IEnumerable<Claim> clains);
        Task<string> GenerateRefreshToken();
        Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    }
}
