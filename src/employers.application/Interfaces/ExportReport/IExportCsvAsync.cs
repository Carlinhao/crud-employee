using employers.domain.Entities.Employer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.application.Interfaces.ExportReport
{
    public interface IExportCsvAsync
    {
        Task<string> ExportCsv(IEnumerable<EmployerEntity> request);
    }
}
