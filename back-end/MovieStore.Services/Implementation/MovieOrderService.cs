using Microsoft.EntityFrameworkCore;
using MovieStore.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Services
{
    public class MovieOrderService : BaseService<MovieOrder>, IMovieOrderService
    {
        public MovieOrderService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IEnumerable<MovieOrder> Get()
        {
            return Repository.Get()
                .ToList();
        }

        public IEnumerable<MovieOrder> GetByUserId(int userId)
        {
            return Repository.Get(m => m.UserId == userId)
                .Include(m => m.Movie)
                .ToList();
        }

        public bool OrderExists(int movieId, int userId)
        {
            return Repository.Get(m => m.MovieId == movieId && m.UserId == userId)
                .Any();
        }

        public override void Remove(int id)
        {
            Repository.Remove(Get(id));
        }
    }
}
