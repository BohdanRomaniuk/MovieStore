using MovieStore.DataAccess;
using System.Collections.Generic;

namespace MovieStore.Services
{
    public interface ICommentService : IService<Comment>
    {
        IEnumerable<Comment> GetByMovieId(int movieId);
    }
}
