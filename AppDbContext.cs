using CropConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace CropConnect
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }
        public DbSet<Account> Account { get; set; }
        public DbSet<Farm> Farm { get; set; }
        public DbSet<Guide> Guide { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Posting> Posting { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Rating> Rating { get; set; }

    }
}
