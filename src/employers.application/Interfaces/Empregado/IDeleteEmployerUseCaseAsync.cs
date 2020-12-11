using System.Threading.Tasks;

namespace employers.application.Interfaces.Empregado
{
    public interface IDeleteEmployerUseCaseAsync
    {
        Task<int?> RunAsync(int id);
    }
}
