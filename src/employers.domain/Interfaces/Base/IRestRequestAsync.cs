using System.Threading.Tasks;

namespace employers.domain.Interfaces.Base
{
    public interface IRestRequestAsync<TRequest, TResponse>
    {
        Task<TResponse> RunAsync(TRequest request);
    }
}
