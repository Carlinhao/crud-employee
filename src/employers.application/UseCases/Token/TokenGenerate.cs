using employers.api.TokenConfiguration;
using employers.domain.Token;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace employers.application.UseCases.Token
{
    public class TokenGenerate : ITokenGenerate
    {
        private readonly IConfiguration _configuration;

        private readonly TokenConfiguration _tokenConfiguration;

        public TokenGenerate(TokenConfiguration tokenConfiguration,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenConfiguration = tokenConfiguration;
        }

        public async Task<string> GenerateAccessToken(IEnumerable<Claim> clains)
        {
            var secreteKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("TokenExtensions:Secret").Value));
            var signCredencials = new SigningCredentials(secreteKey, SecurityAlgorithms.HmacSha256);
            var minutes = Convert.ToDouble(_configuration.GetSection("TokenExtensions:Audience").Value);

            var tokenOptions = new JwtSecurityToken
                (
                    issuer: _configuration.GetSection("TokenExtensions:Issuer").Value,
                    audience:  _configuration.GetSection("TokenExtensions:Audience").Value,
                    claims: clains,
                    expires: DateTime.Now.AddMinutes(minutes),
                    signingCredentials: signCredencials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return await Task.FromResult(token);
        }

        public async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new Byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return await Task.FromResult(Convert.ToBase64String(randomNumber));
            };
        }

        public async Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("TokenExtensions:Secret").Value)),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCulture))
                throw new SecurityTokenException("Invalid token!!!!!!");

            return await Task.FromResult(principal);
        }
    }
}
