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
using System.Threading.Tasks;

namespace employers.infrastructure.Repositories.Employer
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly IConfiguration _configuration;

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
        }


        public async Task<IEnumerable<EmployeeEntity>> GetAll()
        {
            using IDbConnection conn = Connection;
            string query = "SELECT ID_EMP, NOM_EMP, ID_DPTO FROM Empregado";
            conn.Open();
            var result = await conn.QueryAsync<EmployeeEntity>(query);

            return result.ToList();
        }

        public async Task<EmployeeEntity> GetById(object id)
        {
            using IDbConnection conn = Connection;
            string query = $"SELECT ID_EMP, NOM_EMP, ID_DPTO FROM Empregado WHERE ID_EMP = { id }";
            conn.Open();
            var result = await conn.QueryAsync<EmployeeEntity>(query);

            return result.FirstOrDefault();
        }

        public async Task<int?> InsertAsync(EmployerRequest request)
        {
            using IDbConnection conn = Connection;
            conn.Open();
            string query = $"INSERT INTO Empregado (NOM_EMP, ID_DPTO) VALUES('{ request.Name }',{ request.IdDepartment })";
            var result = await conn.ExecuteAsync(query);

            return result;
        }

        public async Task<int?> DeleteAsync(int id)
        {
            using IDbConnection conn = Connection;
            conn.Open();
            string query = $"DELETE FROM Empregado WHERE ID_EMP = { id }";
            var result = await conn.ExecuteAsync(query);

            return result;
        }

        public async Task<ResultResponse> UpdateAsync(EmployeeEntity entity)
        {
            using IDbConnection conn = Connection;
            conn.Open();
            string query = $"UPDATE Empregado SET NOM_EMP= '{entity.Name}'," +
                           $" ID_DPTO={entity.IdDepartament} WHERE ID_EMP={entity.Id}";
            await conn. QueryAsync(query);

            return new ResultResponse { Data = entity, Message = "Update employer success", Success = true };
        }
    }    
}
