using Dapper;
using employers.domain.Interfaces.Repositories.Occupation;
using employers.domain.Requests;
using employers.domain.Responses;
using employers.infrastructure.DbConfiguration.Interfaces;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace employers.infrastructure.Repositories.Occupation
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly IDapperWrapper _conn;
        private StringBuilder _stringBuilder;
        private IDbConnection _dbConnection;

        public OccupationRepository(IDapperWrapper conn)
        {
            _conn = conn;
            _stringBuilder = new StringBuilder();
            _dbConnection = _conn.GetConnection();
        }

        public async Task<ResultResponse> GetAllAsync()
        {
            var query = "SELECT ID_OCCUPATION, LEVEL_OCCUPATION, NOM_OCCUPATION FROM Occupation";
            var result = await _dbConnection.QueryAsync(query);

            return new ResultResponse { Data = result, Message = "List occupation", Success = true };
        }

        public async Task<ResultResponse> InsertAsync(OccupationRequest request)
        {
            var query = $"INSERT INTO Occupation (LEVEL_OCCUPATION, NOM_OCCUPATION) VALUES('{request.LevelOccupation}','{request.NameOccupation}')";
            var result = await _dbConnection.QueryAsync(query);

            return new ResultResponse { Data = result, Message = "Insert success", Success = true };
        }

        public async Task<ResultResponse> UpdateAsync(OccupationUpdateRequest request)
        {
            _stringBuilder.Append($"UPDATE Occupation SET NOM_OCCUPATION = '{request.NameOccupation}', ");
            _stringBuilder.Append($"LEVEL_OCCUPATION = '{request.LevelOccupation}' ");
            _stringBuilder.Append($"WHERE ID_OCCUPATION ={ request.Id}");


            await _dbConnection.QueryAsync(_stringBuilder.ToString());

            return new ResultResponse { Data = request, Message = "Update occupation success", Success = true };
        }
    }
}
