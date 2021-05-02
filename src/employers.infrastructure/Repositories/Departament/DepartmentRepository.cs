using Dapper;
using employers.domain.Entities;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Requests;
using Microsoft.Extensions.Configuration;
using System;
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
                return new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            }
        }

        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<DepartmentEntity>> GetAll()
        {
            using IDbConnection conn = Connection;
            string query = "SELECT ID_DEPARTMENT, NOM_DEPARTMENT, MANGER, DESC_DEPARTMENT FROM Department";
            conn.Open();
            var result = await conn.QueryAsync<DepartmentEntity>(query);

            return result.ToList();
        }

        public async Task<DepartmentEntity> GetById(object id)
        {
            using IDbConnection conn = Connection;
            string query = $"SELECT ID_DEPARTMENT, NOM_DEPARTMENT, MANGER, DESC_DEPARTMENT FROM Department WHERE ID_DEPARTMENT = { id }";
            conn.Open();
            var result = await conn.QueryAsync<DepartmentEntity>(query);

            return result.FirstOrDefault();
        }

        public async Task<int?> InsertAsync(DepartmentRequest request)
        {
            using IDbConnection conn = Connection;
            conn.Open();
            string query = $"INSERT INTO Department (NOM_DEPARTMENT, MANAGER, DESC_DEPARTMENT) VALUES( '{ request.Name }', { request.Manager }, '{ request.Description }')";
            var result = await conn.ExecuteAsync(query);

            return result;
        }
    }
}
