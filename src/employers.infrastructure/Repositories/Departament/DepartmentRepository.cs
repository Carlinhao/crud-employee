using Dapper;
using employers.domain.Entities;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Requests;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace employers.infrastructure.Repositories.Departament
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IConfiguration _configuration;

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("sqlConnect"));
            }
        }

        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<DepartmentEntity>> GetAll()
        {
            using IDbConnection conn = Connection;
            string query = "SELECT ID_DPTO, NOM_DPTO FROM Departamento";
            conn.Open();
            var result = await conn.QueryAsync<DepartmentEntity>(query);

            return result.ToList();
        }

        public async Task<DepartmentEntity> GetById(object id)
        {
            using IDbConnection conn = Connection;
            string query = $"SELECT ID_DPTO, NOM_DPTO FROM Departamento WHERE ID_DPTO = { id }";
            conn.Open();
            var result = await conn.QueryAsync<DepartmentEntity>(query);

            return result.FirstOrDefault();
        }

        public async Task<int?> InsertAsync(DepartmentRequest request)
        {
            using IDbConnection conn = Connection;
            conn.Open();
            string query = $"INSERT INTO Departamento (NOM_DPTO) VALUES( '{ request.Nome }')";
            var result = await conn.ExecuteAsync(query);

            return result;
        }
    }
}
