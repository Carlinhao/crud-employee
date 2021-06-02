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
        private IDbConnection dbConnection;

        public OccupationRepository(IDapperWrapper conn)
        {
            _conn = conn;
            _stringBuilder = new StringBuilder();
            dbConnection = _conn.GetConnection();
        }

        public Task<ResultResponse> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResultResponse> UpdateAsync(OccupationRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
