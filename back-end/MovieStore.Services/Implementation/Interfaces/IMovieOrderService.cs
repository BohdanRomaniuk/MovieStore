using MovieStore.DataAccess;
using System.Collections.Generic;

namespace MovieStore.Services
{
    public interface IMovieOrderService : IService<MovieOrder>
    {
        IEnumerable<MovieOrder> GetByUserId(int userId);
        bool OrderExists(int movieId, int userId);
    }
}
