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

        public IEnumerable<Movie> Search(string searchQuery)
        {
            return Repository.Get(m => m.UkrName.ToLower().Contains(searchQuery.ToLower())
                                    || m.OriginName.ToLower().Contains(searchQuery.ToLower()))
                .ToList();
        }
    }
}
