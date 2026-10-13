using System;
using System.Data;
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

    public async Task<EmployeeResponse> GetAll(Pagination pagination, CancellationToken cancellationToken)
    {

        string  query = """
                             SELECT COUNT(*) [TotalRows] FROM Employee WITH (NOLOCK);
                             SELECT
                                 ID_EMPLOYEE,
                                 NOM_EMPLOYEE,
                                 ID_DEPARTMENT,
                                 ACTIVE,
                                 ID_OCCUPATION,
                                 GENDER
                             FROM Employee
                             """;

        var parameters = new
            { Offset = (pagination.PageNumber - 1) * pagination.PageSize, Limit = pagination.PageSize };

        if (pagination.PageNumber > 0 || pagination.PageSize > 0)
        {
            query = string.Concat(query, " ORDER BY ID_EMPLOYEE OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY;");
        }

        await using var multi = await connection.QueryMultipleAsync(query, parameters, dbTransaction);

        pagination.TotalCount = await multi.ReadFirstOrDefaultAsync<int>();
        var employees = await multi.ReadAsync<EmployeeEntity>();

        pagination.TotalPages = pagination.PageNumber == 0 ? 0 : (int)Math.Ceiling((double)pagination.TotalCount / pagination.PageSize);
        return new EmployeeResponse
        {
            Pagination = pagination,
            Employees = employees
        };
    }

    public async Task<EmployeeEntity> GetById(object id)
    {
        const string query = "SELECT ID_EMPLOYEE, NOM_EMPLOYEE, ID_DEPARTMENT, GENDER, ID_OCCUPATION, ACTIVE FROM Employee WITH (NOLOCK) WHERE ID_EMPLOYEE =  @Id ";
        var parameters = new { Id = id };
        var result = await connection. QueryFirstAsync<EmployeeEntity>(query, parameters, dbTransaction);

        return result;
    }

    public async Task<int?> InsertAsync(EmployerRequest employerRequest)
    {
        const string query = "INSERT INTO Employee (NOM_EMPLOYEE, ID_DEPARTMENT, ID_OCCUPATION, GENDER, ACTIVE) VALUES(@Name,@IdDepartment, @IdOccupation, @Gender, @Active)";

        var parameters = new { Name = employerRequest.Name, IdDepartment = employerRequest.IdDepartment, IdOccupation = employerRequest.IdOccupation, Gender = employerRequest.Gender, Active = employerRequest.Active};

        return await connection.ExecuteAsync(query, parameters, dbTransaction);
    }

    public async Task<int?> DeleteAsync(int id)
    {
        const string query = "DELETE FROM Employee WHERE ID_EMPLOYEE = @Id";
        var parameters = new { Id = id };
        return await connection.ExecuteAsync(query, parameters, dbTransaction);
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
