using System.Threading;
using System.Threading.Tasks;
using employers.domain.Entities;

namespace employers.application.Interfaces.ExportReport;

public interface IExportCsvAsync
{
    Task<string> ExportCsv(Pagination pagination, CancellationToken cancellationToken);
}
