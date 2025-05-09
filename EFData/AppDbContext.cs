using CinemaApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CinemaApp.EFData;


public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Projection> Projections { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Hall has a foreign key to Cinema (CinemaId)
        modelBuilder.Entity<Hall>()
            .HasOne(h => h.Cinema)            // Hall has one Cinema
            .WithMany(c => c.Halls)           // Cinema has many Halls
            .HasForeignKey(h => h.CinemaId)   // Foreign key is CinemaId
            .OnDelete(DeleteBehavior.Cascade); // When Cinema is deleted, delete associated Halls

        // Projection has a foreign key to Movie (MovieId)
        modelBuilder.Entity<Projection>()
            .HasOne(p => p.Movie)            // Projection has one Movie
            .WithMany()                      // Movie can have many Projections
            .HasForeignKey(p => p.MovieId)   // Foreign key is MovieId
            .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Movie if associated Projections exist

        // Projection has a foreign key to Hall (HallId)
        modelBuilder.Entity<Projection>()
            .HasOne(p => p.Hall)             // Projection has one Hall
            .WithMany()                      // Hall can have many Projections
            .HasForeignKey(p => p.HallId)    // Foreign key is HallId
            .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Hall if associated Projections exist

        // Ticket has a foreign key to User (UserId)
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.User)             // Ticket has one User
            .WithMany()                       // User can have many Tickets
            .HasForeignKey(t => t.UserId)    // Foreign key is UserId
            .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of User if associated Tickets exist

        // Ticket has a foreign key to Projection (ProjectionId)
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Projection)       // Ticket has one Projection
            .WithMany()                      // Projection can have many Tickets
            .HasForeignKey(t => t.ProjectionId)  // Foreign key is ProjectionId
            .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Projection if associated Tickets exist

        modelBuilder.Entity<Admin>()
            .HasIndex(a => a.Name) 
            .IsUnique();
    }
}
