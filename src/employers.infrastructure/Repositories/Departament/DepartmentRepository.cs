using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using employers.domain.Entities.Departament;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Requests;

namespace employers.infrastructure.Repositories.Departament;

public class DepartmentRepository(IDbConnection connection,
                            IDbTransaction transaction) : IDepartmentRepository
{
    // TODO Pagination
    public async Task<IEnumerable<DepartmentEntity>> GetAll()
    {
        const string query = "SELECT ID_DEPARTMENT, NOM_DEPARTMENT, MANAGER, DESC_DEPARTMENT FROM Department WITH (NOLOCK)";

        var result = await connection.QueryAsync<DepartmentEntity>(query, null, transaction);

        return [.. result];
    }

    public async Task<DepartmentEntity> GetById(object id)
    {
        string query = $"SELECT ID_DEPARTMENT, NOM_DEPARTMENT, MANAGER, DESC_DEPARTMENT FROM Department WITH (NOLOCK) WHERE ID_DEPARTMENT = { id }";

        var result = await connection.QueryAsync<DepartmentEntity>(query, null, transaction);

        return result.FirstOrDefault();
    }

    public async Task<int?> InsertAsync(DepartmentRequest request)
    {
        string query = $"INSERT INTO Department (NOM_DEPARTMENT, MANAGER, DESC_DEPARTMENT) VALUES( '{ request.Name }', { request.Manager }, '{ request.Description }')";
        var result = await connection.ExecuteAsync(query, null, transaction);

        return result;
    }
}
