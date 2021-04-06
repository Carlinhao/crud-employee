using employers.application.Interfaces.ExportReport;
using employers.domain.Entities.Employer;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace employers.application.UseCases.ExportReport
{
    public class ExportCsvAsync : IExportCsvAsync
    {
        public async Task<string> ExportCsv(IEnumerable<EmployerEntity> request)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Id,Id Departament,Name");
            sb.AppendLine();
            foreach (var item in request)
            {
                sb.AppendFormat("{0},{1},{2},{3}",
                     item.Id,
                     item.IdDepartament,
                     item.Name);
                sb.AppendLine();
            }
            return await Task.FromResult(sb.ToString());
        }
    }
}
