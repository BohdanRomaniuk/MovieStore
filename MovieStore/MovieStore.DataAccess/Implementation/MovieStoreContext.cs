using Microsoft.EntityFrameworkCore;

namespace MovieStore.DataAccess
{
    public class MovieStoreContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieStoreContext(DbContextOptions<MovieStoreContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>().ToTable("Movies");
        }
    }
}