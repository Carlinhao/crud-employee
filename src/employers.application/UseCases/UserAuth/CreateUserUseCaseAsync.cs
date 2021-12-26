using System;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using employers.application.Interfaces.UserAuth;
using employers.domain.Entities.UserAuth;
using employers.domain.Interfaces.Repositories.UserAuth;
using employers.domain.Requests;
using employers.application.Exceptions.RegraNegocio;
using AutoMapper;

namespace employers.application.UseCases.UserAuth
{
    public class CreateUserUseCaseAsync : ICreateUserUseCaseAsync
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserAuthRepository _userAuthRepository;

        public CreateUserUseCaseAsync(IMapper mapper,
                                      IUserRepository userRepository,
                                      IUserAuthRepository userAuthRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userAuthRepository = userAuthRepository;
        }

        public async Task<int> RunAsync(CreateUserRequest request)
        {
            var entity = _mapper.Map<UserEntity>(request);

            var thereAreUser = await _userRepository.FindUser(request.UserName);

            if (thereAreUser == 1)
                throw new RegranegocioException("There is already a user with the same name.");

            entity.Password = ComputeHash(request.Password, new SHA256CryptoServiceProvider());
            return await _userRepository.InsertUser(entity);
        }

        public string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashBytes);
        }
    }
}
