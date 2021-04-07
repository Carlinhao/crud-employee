using employers.application.Interfaces.ExportReport;
using employers.domain.Interfaces.Repositories.Employers;
using System.Text;
using System.Threading.Tasks;

namespace employers.application.UseCases.ExportReport
{
    public class ExportCsvAsync : IExportCsvAsync
    {
        private readonly IEmployerRepository _employerRepository;

        public ExportCsvAsync(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<string> ExportCsv()
        {
            var request = await _employerRepository.GetAll();

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
