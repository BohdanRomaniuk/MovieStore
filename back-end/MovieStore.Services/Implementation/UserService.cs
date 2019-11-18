using MovieStore.DataAccess;
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

        public override void Remove(int id)
        {
            Repository.Remove(Get(id));
        }
    }
}
