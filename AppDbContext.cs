using CropConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace CropConnect
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }
        public DbSet<Guide> Guide { get; set; }
    }
}
