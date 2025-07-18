using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Usuario");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
            .HasColumnName("usuID")
            .HasColumnType("numeric(18, 0)");

            entity.Property(e => e.FirstName)
                .HasColumnName("nombre")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            entity.Property(e => e.LastName)
                .HasColumnName("apellido")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            entity.HasData(
                new User { Id = 1, FirstName = "Andres", LastName = "Rodriguez Vera" },
                new User { Id = 2, FirstName = "Jose", LastName = "Giraldo Perez" },
                new User { Id = 3, FirstName = "Ana", LastName = "Martinez Garcia" },
                new User { Id = 4, FirstName = "Carlos", LastName = "Lopez Fernandez" },
                new User { Id = 5, FirstName = "Maria", LastName = "Sanchez Torres" }
            );
        });
    }
}
