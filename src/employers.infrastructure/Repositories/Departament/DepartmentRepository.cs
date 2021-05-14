using Dapper;
using employers.domain.Entities;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Requests;
using employers.infrastructure.DbConfiguration.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace employers.infrastructure.Repositories.Departament
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly IDapperWrapper _conn;
        private readonly IDbConnection _dbConnection;

        public DepartmentRepository(IDapperWrapper conn)
        {
            _conn = conn;
            _dbConnection = _conn.GetConnection();
        }

        public async Task<IEnumerable<DepartmentEntity>> GetAll()
        {
            string query = "SELECT ID_DEPARTMENT, NOM_DEPARTMENT, MANAGER, DESC_DEPARTMENT FROM Department WITH (NOLOCK)";
            
            var result = await _dbConnection.QueryAsync<DepartmentEntity>(query);

            return result.ToList();
        }

        public async Task<DepartmentEntity> GetById(object id)
        {
            string query = $"SELECT ID_DEPARTMENT, NOM_DEPARTMENT, MANAGER, DESC_DEPARTMENT FROM Department WITH (NOLOCK) WHERE ID_DEPARTMENT = { id }";
            
            var result = await _dbConnection.QueryAsync<DepartmentEntity>(query);

            return result.FirstOrDefault();
        }

        public async Task<int?> InsertAsync(DepartmentRequest request)
        {
            string query = $"INSERT INTO Department (NOM_DEPARTMENT, MANAGER, DESC_DEPARTMENT) VALUES( '{ request.Name }', { request.Manager }, '{ request.Description }')";
            var result = await _dbConnection.ExecuteAsync(query);

            return result;
        }
    }
}
