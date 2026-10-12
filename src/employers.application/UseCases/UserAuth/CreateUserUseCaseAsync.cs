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

namespace employers.application.UseCases.UserAuth;

public class CreateUserUseCaseAsync(IMapper mapper,
                                    IUnitOfWork unitOfWork) : ICreateUserUseCaseAsync
{
    public async Task<int> RunAsync(CreateUserRequest request)
    {
        var entity = mapper.Map<UserEntity>(request);

        var thereAreUser = await unitOfWork.UserRepository.FindUser(request.UserName);

        if (thereAreUser == 1)
            throw new RegranegocioException("There is already a user with the same name.");

        entity.Password = ComputeHash(request.Password, new HMACMD5());

        var result = await unitOfWork.UserRepository.InsertUser(entity);
        unitOfWork.Transaction();

        return result;
    }

    public static string ComputeHash(string input, HMACMD5 algorithm)
    {
        Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        Byte[] hashBytes = algorithm.ComputeHash(inputBytes);

        return BitConverter.ToString(hashBytes);
    }
}
