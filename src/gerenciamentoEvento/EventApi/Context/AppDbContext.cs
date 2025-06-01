using Microsoft.EntityFrameworkCore;
using EventApi.Models;

namespace EventApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
