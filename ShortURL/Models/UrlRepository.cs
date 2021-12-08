using System.Linq;

namespace ShortURL.Models
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ShortURLContext _context;

        public UrlRepository(ShortURLContext context)
        {
            _context = context;
        }
        
        public Url Add(Url url)
        {
            _context.Add(url);
            _context.SaveChanges();

            return url;
        }

        public Url Get(string shortUrl)
        {
            return _context.Urls
                .Where(u => u.ShortUrl == shortUrl)
                .FirstOrDefault();
        }
    }
}
