using System;
using System.Threading.Tasks;
using employers.application.Interfaces.UserAuth;
using employers.domain.Interfaces.Repositories;
using employers.domain.Responses;
using employers.domain.Token;
using Microsoft.Extensions.Configuration;

namespace employers.application.UseCases.UserAuth
{
    public class UserAuthRefreshTokenUseCaseAsync : IUserAuthRefreshTokenUseCaseAsync
    {
        private const string DATE_FORMATE = "yyyy-MM--dd HH:mm:ss";

        private readonly ITokenGenerate _tokenGenerate;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public UserAuthRefreshTokenUseCaseAsync(
            ITokenGenerate tokenGenerate,
            IUnitOfWork unitOfWork, 
            IConfiguration configuration)
        {
            _tokenGenerate = tokenGenerate;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<TokenResponse> RunAsync(TokenResponse request)
        {
            var accessToken = request.AccessToken;
            var refreshToken = request.RefreshToken;
            var principal = await _tokenGenerate.GetPrincipalFromExpiredToken(accessToken);
            
            var user = await _unitOfWork.UserAuthRepository.ValidateCredentials(principal.Identity.Name);

            if (user == null || 
                user.RefreshToken != refreshToken || 
                user.RefreshTokenExpire <= DateTime.Now) return null;

            accessToken = await _tokenGenerate.GenerateAccessToken(principal.Claims);
            refreshToken = await _tokenGenerate.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            await _unitOfWork.UserAuthRepository.RefresUserInfo(user);

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
