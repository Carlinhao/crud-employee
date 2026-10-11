using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using employers.domain.Entities;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Requests;
using employers.domain.Responses;

namespace employers.infrastructure.Repositories.Employer;

public class EmployerRepository(IDbConnection connection,
                                IDbTransaction dbTransaction) : IEmployerRepository
{
    private readonly StringBuilder _stringBuilder = new ();

    // TODO Add Pagination
    public async Task<IEnumerable<EmployeeEntity>> GetAll(Pagination pagination, CancellationToken cancellationToken)
    {
        const string query = @"SELECT ID_EMPLOYEE, NOM_EMPLOYEE, ID_DEPARTMENT, ACTIVE, ID_OCCUPATION, GENDER FROM Employee WITH (NOLOCK)";

        var result = await connection.QueryAsync<EmployeeEntity>(query, null, dbTransaction);

        return [.. result];
    }

    public async Task<EmployeeEntity> GetById(object id)
    {
        string query = $"SELECT ID_EMPLOYEE, NOM_EMPLOYEE, ID_DEPARTMENT, GENDER, ID_OCCUPATION, ACTIVE FROM Employee WITH (NOLOCK) WHERE ID_EMPLOYEE = { id }";

        var result = await connection.QueryAsync<EmployeeEntity>(query, null, dbTransaction);

        return result.FirstOrDefault();
    }

    public async Task<int?> InsertAsync(EmployerRequest request)
    {
        string query = $"INSERT INTO Employee (NOM_EMPLOYEE, ID_DEPARTMENT, ID_OCCUPATION, GENDER, ACTIVE) VALUES('{ request.Name }',{ request.IdDepartment }, { request.IdOccupation }, '{ request.Gender }', '{ request.Active }')";

        var result = await connection.QueryAsync(query, null, dbTransaction);

        return result.FirstOrDefault();
    }

    public async Task<int?> DeleteAsync(int id)
    {
        string query = $"DELETE FROM Employee WHERE ID_EMPLOYEE = { id }";
        var result = await connection.ExecuteAsync(query, null, dbTransaction);

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


        await connection.QueryAsync(_stringBuilder.ToString(), null, dbTransaction);

        return new ResultResponse { Data = entity, Message = "Update employer success", Success = true };
    }
}
