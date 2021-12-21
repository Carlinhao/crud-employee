﻿using System.Threading.Tasks;
using employers.domain.Entities.UserAuth;

namespace employers.domain.Interfaces.Repositories.UserAuth
{
    public interface IUserRepository
    {
        Task<int> InsertUser(UserEntity userEntity);
        Task<bool> DisableUser(int id);
    }
}
