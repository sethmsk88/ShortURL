using System.Threading.Tasks;

namespace ShortURL.Models
{
    public interface IUrlRepository
    {
        Task<Url> Add(Url url);
        Task<Url> Get(string shortUrl);
    }
}
