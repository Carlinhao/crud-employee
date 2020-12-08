﻿using employers.domain.Entities.Employer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.domain.Interfaces.Repositories.Employers
{
    public interface IEmployerRepository
    {
        Task<EmployerEntity> GetById(object id);
        Task<IEnumerable<EmployerEntity>> GetAll();
    }
}