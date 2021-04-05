using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.application.Interfaces.ExportReport
{
    public interface IExportPdfAsync
    {
        Task<string> ExportPdf(IEnumerable<object> request);
    }
}
