using Microsoft.Extensions.Configuration;
using employers.application.Interfaces.UserAuth;
using employers.domain.Interfaces.Repositories.UserAuth;
using employers.domain.Responses;
using employers.domain.Token;
using employers.domain.UserAuth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;


namespace employers.application.UseCases.UserAuth
{
    public class UserAuthUseCaseAsync : IUserAuthUseCaseAsync
    {
        private const string DATE_FORMATE = "yyyy-MM--dd HH:mm:ss";

        private readonly ITokenGenerate _tokenGenerate;
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IConfiguration _configuration;

        public UserAuthUseCaseAsync(
            ITokenGenerate tokenGenerate,
            IUserAuthRepository userAuthRepository,
            IConfiguration configuration)
        {
            _tokenGenerate = tokenGenerate;
            _userAuthRepository = userAuthRepository;
            _configuration = configuration;
        }

        public async Task<TokenResponse> RunAsync(UserInfoRequest request)
        {
            var user = await _userAuthRepository.ValidateCredentials(request);
            if (user == null) return null;

            var clains = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var accessToken = await _tokenGenerate.GenerateAccessToken(clains);
            var refreshToken = await _tokenGenerate.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.AcessToken = accessToken;
            user.RefreshTokenExpire = DateTime.Now.AddDays(Convert.ToDouble(_configuration.GetSection("TokenExtensions:DaysToExpiry").Value));

            await _userAuthRepository.RefresUserInfo(user);

            var createDate = DateTime.Now;
            var expireDate = createDate.AddMinutes(Convert.ToDouble(_configuration.GetSection("TokenExtensions:Minutes").Value));

            
            return new TokenResponse 
            { 
                Authenticated = true,
                AccessToken = accessToken,
                Created = createDate.ToString(DATE_FORMATE),
                Expiration = expireDate.ToString(),
                RefreshToken = refreshToken
            };
        }
    }
}
