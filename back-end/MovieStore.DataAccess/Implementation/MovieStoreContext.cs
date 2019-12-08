using Microsoft.EntityFrameworkCore;

namespace MovieStore.DataAccess
{
    public class MovieStoreContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MovieRate> MovieRates { get; set; }
        public DbSet<MovieOrder> MovieOrders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }

        public MovieStoreContext(DbContextOptions<MovieStoreContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>().ToTable("Movies");

            builder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(p => p.DirectingMovies)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<MovieCountry>()
                .HasKey(mc => new { mc.MovieId, mc.CountryId });
            builder.Entity<MovieCountry>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.Countries)
                .HasForeignKey(mc => mc.MovieId);
            builder.Entity<MovieCountry>()
                .HasOne(mc => mc.Country)
                .WithMany(m => m.Movies)
                .HasForeignKey(mc => mc.CountryId);

            builder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });
            builder.Entity<MovieGenre>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.Genres)
                .HasForeignKey(mc => mc.MovieId);
            builder.Entity<MovieGenre>()
                .HasOne(mc => mc.Genre)
                .WithMany(m => m.Movies)
                .HasForeignKey(mc => mc.GenreId);

            builder.Entity<MovieActor>()
               .HasKey(ma => new { ma.MovieId, ma.PersonId });
            builder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(ma => ma.MovieId);
            builder.Entity<MovieActor>()
                .HasOne(ma => ma.Person)
                .WithMany(p => p.ActingInMovies)
                .HasForeignKey(ma => ma.PersonId);

            builder.Entity<MovieCompany>()
               .HasKey(mc => new { mc.MovieId, mc.CompanyId });
            builder.Entity<MovieCompany>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.Companies)
                .HasForeignKey(mc => mc.MovieId);
            builder.Entity<MovieCompany>()
                .HasOne(mc => mc.Company)
                .WithMany(m => m.Movies)
                .HasForeignKey(mc => mc.CompanyId);
        }
    }
}