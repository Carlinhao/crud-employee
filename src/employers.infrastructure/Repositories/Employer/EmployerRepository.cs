using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Requests;
using employers.domain.Responses;

namespace employers.infrastructure.Repositories.Employer
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly StringBuilder _stringBuilder;
        private readonly IDbTransaction _dbTransaction;
        private readonly IDbConnection _connection;


        public EmployerRepository(IDbConnection connection,
                                  IDbTransaction dbTransaction)
        {
            _stringBuilder = new StringBuilder();
            _connection = connection;
            _dbTransaction = dbTransaction;
        }


        public async Task<IEnumerable<EmployeeEntity>> GetAll()
        {
            string query = @"SELECT ID_EMPLOYEE, NOM_EMPLOYEE, ID_DEPARTMENT, ACTIVE, ID_OCCUPATION, GENDER FROM Employee WITH (NOLOCK)";
            
            var result = await _connection.QueryAsync<EmployeeEntity>(query, null, _dbTransaction);

            return result.ToList();
        }

        public async Task<EmployeeEntity> GetById(object id)
        {
            string query = $"SELECT ID_EMPLOYEE, NOM_EMPLOYEE, ID_DEPARTMENT, GENDER, ID_OCCUPATION, ACTIVE FROM Employee WITH (NOLOCK) WHERE ID_EMPLOYEE = { id }";
            
            var result = await _connection.QueryAsync<EmployeeEntity>(query, null, _dbTransaction);

            return result.FirstOrDefault();
        }

        public async Task<int?> InsertAsync(EmployerRequest request)
        {
            string query = $"INSERT INTO Employee (NOM_EMPLOYEE, ID_DEPARTMENT, ID_OCCUPATION, GENDER, ACTIVE) VALUES('{ request.Name }',{ request.IdDepartment }, { request.IdOccupation }, '{ request.Gender }', '{ request.Active }')";
            
            var result = await _connection.QueryAsync(query, null, _dbTransaction);

            return result.FirstOrDefault();
        }

        public async Task<int?> DeleteAsync(int id)
        {
            string query = $"DELETE FROM Employee WHERE ID_EMPLOYEE = { id }";
            var result = await _connection.ExecuteAsync(query, null, _dbTransaction);

            return result;
        }

        public async Task<ResultResponse> UpdateAsync(EmployeeEntity entity)
        {
            _stringBuilder.Append($"UPDATE Employee SET NOM_EMPLOYEE = '{entity.Name}', ");
            _stringBuilder.Append($"ID_DEPARTMENT = {entity.IdDepartament}, ");
            _stringBuilder.Append($"ID_OCCUPATION = {entity.IdOccupation}, ");
            _stringBuilder.Append($"GENDER = '{entity.Gender}', ");
            _stringBuilder.Append($"ACTIVE = '{entity.Active}' ");
            _stringBuilder.Append($"WHERE ID_EMPLOYEE ={entity.Id}");


            await _connection.QueryAsync(_stringBuilder.ToString(), null, _dbTransaction);

            return new ResultResponse { Data = entity, Message = "Update employer success", Success = true };
        }
    }    
}
