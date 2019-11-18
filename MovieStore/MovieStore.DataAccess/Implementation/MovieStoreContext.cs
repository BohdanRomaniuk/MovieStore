using Microsoft.EntityFrameworkCore;

namespace MovieStore.DataAccess
{
    public class MovieStoreContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MovieRate> MovieRates { get; set; }
        public DbSet<User> Users { get; set; }

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