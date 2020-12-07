using Dapper;
using employers.domain.Entities.Employer;
using employers.domain.Interfaces.Repositories.Employers;
using Microsoft.Extensions.Configuration;
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
                return new SqlConnection(_configuration.GetConnectionString("sqlConnect"));
            }
        }

        public async Task<IEnumerable<EmployerEntity>> GetAll()
        {
            using IDbConnection conn = Connection;
            string query = "SELECT ID_DPTO, NOM_DPTO FROM Empregado";
            conn.Open();
            var result = await conn.QueryAsync<EmployerEntity>(query);

            return result.ToList();
        }

        public async Task<EmployerEntity> GetById(object id)
        {
            using IDbConnection conn = Connection;
            string query = $"SELECT ID_DPTO, NOM_DPTO FROM Empregado WHERE ID_EMP = { id }";
            conn.Open();
            var result = await conn.QueryAsync<EmployerEntity>(query);

            return result.FirstOrDefault();
        }
    }
}
