using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.application.Interfaces.ExportReport
{
    public interface IExportXmlAsync
    {
        Task<string> ExportXml(IEnumerable<object> request);
    }
}
