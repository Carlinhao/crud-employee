using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using employers.application.Exceptions.RegraNegocio;
using employers.application.Interfaces.UserAuth;
using employers.domain.Entities.UserAuth;
using employers.domain.Interfaces.Repositories;
using employers.domain.Requests;

namespace employers.application.UseCases.UserAuth
{
    public class CreateUserUseCaseAsync : ICreateUserUseCaseAsync
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserUseCaseAsync(IMapper mapper,
                                      IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> RunAsync(CreateUserRequest request)
        {
            var entity = _mapper.Map<UserEntity>(request);

            var thereAreUser = await _unitOfWork.UserRepository.FindUser(request.UserName);

            if (thereAreUser == 1)
                throw new RegranegocioException("There is already a user with the same name.");

            entity.Password = ComputeHash(request.Password, new SHA256CryptoServiceProvider());
            return await _unitOfWork.UserRepository.InsertUser(entity);
        }

        public string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashBytes);
        }
    }
}
