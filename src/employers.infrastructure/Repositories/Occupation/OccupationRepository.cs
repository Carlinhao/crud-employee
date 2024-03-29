﻿using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using employers.domain.Interfaces.Repositories.Occupation;
using employers.domain.Requests;
using employers.domain.Responses;

namespace employers.infrastructure.Repositories.Occupation
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly StringBuilder _stringBuilder;
        private readonly IDbConnection _dbConnection;
        private readonly IDbTransaction _dbTransaction;

        public OccupationRepository(IDbConnection dbConnection,
                                    IDbTransaction dbTransaction)
        {
            _stringBuilder = new StringBuilder();
            _dbConnection = dbConnection;
            _dbTransaction = dbTransaction;
        }

        public async Task<ResultResponse> GetAllAsync()
        {
            var query = "SELECT ID_OCCUPATION, LEVEL_OCCUPATION, NOM_OCCUPATION FROM Occupation";
            var result = await _dbConnection.QueryAsync(query, null, _dbTransaction);

            return new ResultResponse { Data = result, Message = "List occupation", Success = true };
        }

        public async Task<ResultResponse> InsertAsync(OccupationRequest request)
        {
            var query = $"INSERT INTO Occupation (LEVEL_OCCUPATION, NOM_OCCUPATION) VALUES('{request.LevelOccupation}','{request.NameOccupation}')";
            var result = await _dbConnection.QueryAsync(query, null, _dbTransaction);

            return new ResultResponse { Data = result, Message = "Insert success", Success = true };
        }

        public async Task<ResultResponse> UpdateAsync(OccupationUpdateRequest request)
        {
            _stringBuilder.Append($"UPDATE Occupation SET NOM_OCCUPATION = '{request.NameOccupation}', ");
            _stringBuilder.Append($"LEVEL_OCCUPATION = '{request.LevelOccupation}' ");
            _stringBuilder.Append($"WHERE ID_OCCUPATION ={ request.Id}");


            await _dbConnection.QueryAsync(_stringBuilder.ToString(), null, _dbTransaction);

            return new ResultResponse { Data = request, Message = "Update occupation success", Success = true };
        }
    }
}
