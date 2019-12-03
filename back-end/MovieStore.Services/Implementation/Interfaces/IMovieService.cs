using MovieStore.DataAccess;
using System.Collections.Generic;

namespace MovieStore.Services
{
    public interface IMovieService : IService<Movie>
    {
        IEnumerable<Movie> Search(string searchQuery);
    }
}
