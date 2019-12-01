using MovieStore.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MovieStore.Services
{
    public class MovieService : BaseService<Movie>, IMovieService
    {
        public MovieService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IEnumerable<Movie> Get()
        {
            return Repository.Get()
                .Include(c => c.Comments)
                .Include(c => c.MovieRates)
                .ToList();
        }

        public override Movie Get(int id)
        {
            return Repository.Get(m => m.Id == id)
                .Include(c => c.Comments).ThenInclude(m => m.User)
                .Include(c => c.MovieRates)
                .FirstOrDefault();
        }

        public override void Remove(int id)
        {
            Repository.Remove(Get(id));
        }
    }
}
