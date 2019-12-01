using MovieStore.DataAccess;
using MovieStore.DataTransfer.Objects;

namespace MovieStore.Services
{
    public interface IUserService : IService<User>
    {
        bool ValidateUserPassword(UserLoginDTO user);
        UserIdentityDTO GetUserIdentity(string username);
        UserIdentityDTO CreateUser(UserRegistrationDTO user);
    }
}
