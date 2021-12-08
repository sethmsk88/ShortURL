using Microsoft.EntityFrameworkCore;

namespace ShortURL.Models
{
    public class ShortURLContext : DbContext
    {
        public ShortURLContext(DbContextOptions<ShortURLContext> options)
            : base(options)
        {
        }

        public DbSet<Url> Urls { get; set; }
    }
}
