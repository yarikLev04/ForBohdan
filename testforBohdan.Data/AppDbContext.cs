using Microsoft.EntityFrameworkCore;
using testforBohdan.Abstractions.Entities;

namespace testforBohdan.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Note> Notes { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().HasKey(x => x.Id);

        modelBuilder.Entity<Note>()
            .Property(b => b.Title)
            .IsRequired();

        modelBuilder.Entity<User>().HasKey(x => x.Id);

        modelBuilder.Entity<User>()
            .HasMany(x => x.Notes)
            .WithOne(u => u.User)
            .HasForeignKey(e => e.UserId);
    }
}