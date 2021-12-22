using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using employers.domain.Entities;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Requests;

namespace employers.infrastructure.Repositories.Departament
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<DepartmentEntity>> GetAll()
        {
            string query = "SELECT ID_DEPARTMENT, NOM_DEPARTMENT, MANAGER, DESC_DEPARTMENT FROM Department WITH (NOLOCK)";
            
            var result = await _connection.QueryAsync<DepartmentEntity>(query);

            return result.ToList();
        }

        public async Task<DepartmentEntity> GetById(object id)
        {
            string query = $"SELECT ID_DEPARTMENT, NOM_DEPARTMENT, MANAGER, DESC_DEPARTMENT FROM Department WITH (NOLOCK) WHERE ID_DEPARTMENT = { id }";
            
            var result = await _connection.QueryAsync<DepartmentEntity>(query);

            return result.FirstOrDefault();
        }

        public async Task<int?> InsertAsync(DepartmentRequest request)
        {
            string query = $"INSERT INTO Department (NOM_DEPARTMENT, MANAGER, DESC_DEPARTMENT) VALUES( '{ request.Name }', { request.Manager }, '{ request.Description }')";
            var result = await _connection.ExecuteAsync(query);

            return result;
        }
    }
}
