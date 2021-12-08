using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShortURL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortController : ControllerBase
    {
        private const string CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const int ShortUrlLength = 7;
        private readonly Random _random = new Random();
        private readonly IUrlRepository _urlRepository;
        private readonly IConfiguration _config;

        public ShortController(IUrlRepository urlRepository,
            IConfiguration config)
        {
            _urlRepository = urlRepository;
            _config = config;
        }

        [HttpGet]
        [Route("{shortUrl}")]
        public IActionResult GetShortUrlRedirect(string shortUrl)
        {
            // Lookup the long url associated with the given short url
            Url url = _urlRepository.Get(shortUrl);

            if (url == null)
            {
                return NotFound();
            }

            return Redirect(url.LongUrl);
        }

        [HttpPost]
        public IActionResult CreateShortUrl(UrlDto urlDto)
        {
            string shortUrl = GenerateRandomUrl();

            // Check if short url already exists in database
            // Keep generating new ones until we have a unique short url
            while (_urlRepository.Get(shortUrl) != null)
            {
                shortUrl = GenerateRandomUrl();
            }

            Url url = new Url
            {
                ShortUrl = shortUrl,
                LongUrl = urlDto.LongUrl,
                CreatedDate = DateTime.Now
            };

            // Insert new url record into database
            _urlRepository.Add(url);

            return Ok($"{ _config.GetValue<string>("AppDomain") }/api/short/{ url.ShortUrl }");
        }

        private string GenerateRandomUrl()
        {
            int randNum;
            string randString = "";

            for (int i = 0; i < ShortUrlLength; i++)
            {
                randNum = _random.Next();
                randString += CharSet[randNum % CharSet.Length];
            }

            return randString;
        }

        
    }
}
