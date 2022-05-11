﻿using System.Threading.Tasks;
using employers.application.Interfaces.Occupation;
using employers.domain.Interfaces.Repositories;
using employers.domain.Requests;
using employers.domain.Responses;

namespace employers.application.UseCases.Occupation
{
    public class InsertOccupationUseCaseAsync : IInsertOccupationUseCaseAsync
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsertOccupationUseCaseAsync(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultResponse> RunAsync(OccupationRequest request)
        {
            return await _unitOfWork.OccupationRepository.InsertAsync(request);
        }
    }
}
