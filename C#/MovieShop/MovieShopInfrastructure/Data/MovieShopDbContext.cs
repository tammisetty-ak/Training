using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieShopCore.Entities;

namespace MovieShopInfrastructure.Data;

public class MovieShopDbContext : DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Genre> Genres { get; set; }
    
    public DbSet<Movie> Movies { get; set; }
    
    public DbSet<Trailer> Trailers { get; set; }
    
    public DbSet<MovieGenre> MovieGenres { get; set; }
    
    public DbSet<Cast> Casts { get; set; }
    
    public DbSet<MovieCast> MovieCasts { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Favorite> Favorites { get; set; }
    
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<Purchase> Purchases { get; set; }
    
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(ConfigureMovie);
        modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
        modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
        modelBuilder.Entity<Favorite>(ConfigureFavorite);
        modelBuilder.Entity<Review>(ConfigureReview);
        modelBuilder.Entity<Purchase>(ConfigurePurchase);
        modelBuilder.Entity<UserRole>(ConfigureUserRole);
    }

    private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });
        builder.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
        builder.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
    }

    private void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasKey(p => new { p.UserId, p.MovieId });
        builder.HasOne(p => p.Movie).WithMany(m => m.Purchases).HasForeignKey(p => p.MovieId);
        builder.HasOne(p => p.User).WithMany(u => u.Purchases).HasForeignKey(p => p.UserId);
        builder.Property(p => p.TotalPrice).HasColumnType("decimal(5,2)");
    }

    private void ConfigureReview(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => new { r.UserId, r.MovieId });
        builder.HasOne(r => r.User).WithMany(u => u.Reviews).HasForeignKey(r => r.UserId);
        builder.HasOne(r => r.Movie).WithMany(m => m.Reviews).HasForeignKey(r => r.MovieId);
        builder.Property(r => r.Rating).HasColumnType("decimal(3,1)").HasDefaultValue(0);

    }

    private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
    {
        builder.HasKey(f => new { f.UserId, f.MovieId });
        builder.HasOne(u => u.User).WithMany(m => m.Favorites).HasForeignKey(f => f.UserId);
        builder.HasOne(u => u.Movie).WithMany(m => m.Favorites).HasForeignKey(f => f.MovieId);
    }

    private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
    {
        builder.HasKey(mc => new {mc.MovieId, mc.CastId});
        builder.HasOne(m => m.Movie).WithMany(c => c.Cast).HasForeignKey(m => m.MovieId);
        builder.HasOne(c => c.Cast).WithMany(c => c.Movies).HasForeignKey(c => c.CastId);
    }

    private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
    {
        builder.HasKey(mg => new { mg.MovieId, mg.GenreId });
        builder.HasOne(m => m.Movie).WithMany(g => g.Genres).HasForeignKey(m => m.MovieId);
        builder.HasOne(g => g.Genre).WithMany(g => g.Movies).HasForeignKey(g => g.GenreId);
    }

    private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).HasColumnType("varchar(200)");
        builder.Property(m => m.Overview).HasMaxLength(4096);
        builder.Property(m => m.PosterUrl).HasMaxLength(2084);
        builder.Property(m => m.TagLine).HasMaxLength(512);
        builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
        builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
        builder.Property(m => m.BackdropURL).HasMaxLength(2084);
        builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
        builder.Property(m => m.Price).HasColumnType("decimal(5,2)").HasDefaultValue(9.9m);
        builder.Property(m => m.Budget).HasColumnType("decimal(18,4)").HasDefaultValue(0);
        builder.Property(m => m.Revenue).HasColumnType("decimal(18,4)").HasDefaultValue(0);
        builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
    }
}