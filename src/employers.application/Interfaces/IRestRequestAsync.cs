using System.Threading.Tasks;

namespace employers.application.Interfaces
{
    public interface IRestRequestAsync<TResponse, TRequest>
    {
        Task<TResponse> RunAsync(TRequest request);
    }
}
