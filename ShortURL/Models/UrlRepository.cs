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
            // Prepend http:// to URL if it is missing
            if (url.LongUrl.StartsWith("http://") == false
                && url.LongUrl.StartsWith("https://") == false)
            {
                url.LongUrl = "http://" + url.LongUrl;
            }

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
