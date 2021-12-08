namespace ShortURL.Models
{
    public interface IUrlRepository
    {
        Url Add(Url url);
        Url Get(string shortUrl);
    }
}
