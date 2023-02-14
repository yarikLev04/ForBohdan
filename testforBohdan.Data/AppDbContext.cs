using Microsoft.EntityFrameworkCore;
using testforBohdat.Abstractions.Entities;

namespace testforBohdat.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Note> Notes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().HasKey(x => x.Id);

        modelBuilder.Entity<Note>()
            .Property(b => b.Title)
            .IsRequired();
    }
}