using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShortURL.Models
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ShortURLContext _context;

        public UrlRepository(ShortURLContext context)
        {
            _context = context;
        }
        
        public async Task<Url> Add(Url url)
        {
            // Prepend http:// to URL if it is missing
            if (url.LongUrl.StartsWith("http://") == false
                && url.LongUrl.StartsWith("https://") == false)
            {
                url.LongUrl = "http://" + url.LongUrl;
            }

            var result = await _context.Urls.AddAsync(url);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Url> Get(string shortUrl)
        {
            return await _context.Urls
                .FirstOrDefaultAsync(u => u.ShortUrl == shortUrl);
        }
    }
}
