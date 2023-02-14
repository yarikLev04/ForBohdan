using Microsoft.EntityFrameworkCore;
using testforBohdan.Models;

namespace testforBohdan.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Note> Notes { get; set; }
}