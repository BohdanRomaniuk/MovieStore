using MovieStore.DataAccess;
using System.Linq;

namespace MovieStore.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override Role Get(int id)
        {
            return Repository.Get(m => m.Id == id)
                .FirstOrDefault();
        }
    }
}
