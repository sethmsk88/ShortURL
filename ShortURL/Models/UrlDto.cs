using System;
using System.ComponentModel.DataAnnotations;

namespace ShortURL.Models
{
    public class UrlDto
    {
        [Required]
        [MaxLength(2048)]
        public string LongUrl { get; set; }
        public string ShortUrlWithDomain { get; set; }
    }
}
