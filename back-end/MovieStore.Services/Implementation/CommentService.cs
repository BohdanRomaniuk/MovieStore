using Microsoft.EntityFrameworkCore;
using MovieStore.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IEnumerable<Comment> Get()
        {
            return Repository.Get()
                .ToList();
        }

        public override Comment Get(int id)
        {
            return Repository.Get(m => m.Id == id)
                .Include(c => c.User)
                .FirstOrDefault();
        }

        public IEnumerable<Comment> GetByMovieId(int movieId)
        {
            return Repository.Get(m => m.MovieId == movieId)
                .Include(c => c.User)
                .ToList();
        }

        public override void Remove(int id)
        {
            Repository.Remove(Get(id));
        }
    }
}
