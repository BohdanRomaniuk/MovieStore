using MovieStore.DataAccess;
using MovieStore.DataTransfer.Objects;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IEnumerable<User> Get()
        {
            return Repository.Get()
                .ToList();
        }

        public override User Get(int id)
        {
            return Repository.Get(m => m.Id == id)
                .FirstOrDefault();
        }

        public UserIdentityDTO GetUserIdentity(string username)
        {
            User user = Repository.Get(u => u.UserName == username)
                .FirstOrDefault();
            return user != null 
                ? new UserIdentityDTO() 
                {
                    Id = user.Id,
                    Role = user.Role,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                } 
                : null;
        }

        public override void Remove(int id)
        {
            Repository.Remove(Get(id));
        }

        public bool ValidateUserPassword(UserLoginDTO user)
        {
            // TODO: validate hashed password in database. FOr now return true if usernames match
            if (Repository.Get(u => u.UserName == user.Username).Any())
                return true;
            return false;
        }
    }
}
