namespace WayfindrWebApp.Data;
using Microsoft.EntityFrameworkCore;
using WayfindrWebApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
