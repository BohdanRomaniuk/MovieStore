using MovieStore.DataAccess;
using System.Linq;
using System.Collections.Generic;

namespace MovieStore.Services
{
    public class MovieService : BaseService<Movie>, IMovieService
    {
        public MovieService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override Movie Get(int id)
        {
            return Repository.Get(m => m.Id == id).FirstOrDefault();
        }

        public override void Remove(int id)
        {
            Repository.Remove(Get(id));
        }
    }
}
