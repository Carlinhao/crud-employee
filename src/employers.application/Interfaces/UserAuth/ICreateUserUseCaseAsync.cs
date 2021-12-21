using employers.domain.Requests;

namespace employers.application.Interfaces.UserAuth
{
    public interface ICreateUserUseCaseAsync :
        IRestRequestAsync<int, CreateUserRequest>
    {
    }
}
