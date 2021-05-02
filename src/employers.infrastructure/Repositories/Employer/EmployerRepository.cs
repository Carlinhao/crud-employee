using Dapper;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Requests;
using employers.domain.Responses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employers.infrastructure.Repositories.Employer
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly IConfiguration _configuration;
        private StringBuilder _stringBuilder;
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            }
        }

        public EmployerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringBuilder = new StringBuilder();
        }


        public async Task<IEnumerable<EmployeeEntity>> GetAll()
        {
            using IDbConnection conn = Connection;
            string query = @"SELECT ID_EMPLOYEE, NOM_EMPLOYEE, ID_DEPARTMENT, ACTIVE, ID_OCCUPATION FROM Employee WITH (NOLOCK)";
            conn.Open();
            var result = await conn.QueryAsync<EmployeeEntity>(query);

            return result.ToList();
        }

        public async Task<EmployeeEntity> GetById(object id)
        {
            using IDbConnection conn = Connection;
            string query = $"SELECT ID_EMPLOYEE, NOM_EMPLOYEE, ID_DPTO FROM Empregado WITH (NOLOCK) WHERE ID_EMPLOYEE = { id }";
            conn.Open();
            var result = await conn.QueryAsync<EmployeeEntity>(query);

            return result.FirstOrDefault();
        }

        public async Task<int?> InsertAsync(EmployerRequest request)
        {
            using IDbConnection conn = Connection;
            conn.Open();
            string query = $"INSERT INTO Employee (NOM_EMPLOYEE, ID_DEPARTMENT, ID_OCCUPATION, GENDER, ACTIVE) VALUES('{ request.Name }',{ request.IdDepartment }, { request.IdOccupation }, '{ request.Gender }', '{ request.Active }')";
            var result = await conn.QueryAsync(query);

            return result.FirstOrDefault();
        }

        public async Task<int?> DeleteAsync(int id)
        {
            using IDbConnection conn = Connection;
            conn.Open();
            string query = $"DELETE FROM Employee WHERE ID_DEPARTMENT = { id }";
            var result = await conn.ExecuteAsync(query);

            return result;
        }

        public async Task<ResultResponse> UpdateAsync(EmployeeEntity entity)
        {
            using IDbConnection conn = Connection;
            conn.Open();
            _stringBuilder.Append($"UPDATE Employee SET NOM_EMPLOYEE = '{entity.Name}', ");
            _stringBuilder.Append($"ID_DEPARTMENT = {entity.IdDepartament}, ");
            _stringBuilder.Append($"ID_OCCUPATION = {entity.IdOccupation}, ");
            _stringBuilder.Append($"GENDER = {entity.Gender}, ");
            _stringBuilder.Append($"ACTIVE = {entity.Active}, ");
            _stringBuilder.Append($"WHERE ID_DEPARTMENT={entity.Id}");


            await conn. QueryAsync(_stringBuilder.ToString());

            return new ResultResponse { Data = entity, Message = "Update employer success", Success = true };
        }
    }    
}
