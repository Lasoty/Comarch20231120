using Bibliotekarz.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Bibliotekarz.Server.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Borrowers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Book>().Property(e => e.Title).IsRequired().HasMaxLength(150);

        builder.Entity<Book>()
            .HasOne(e => e.Borrower)
            .WithMany()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
