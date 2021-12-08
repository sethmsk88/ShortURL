using System;
using System.ComponentModel.DataAnnotations;

namespace ShortURL.Models
{
    public class Url
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(2048)]
        public string LongUrl { get; set; }
        [Required]
        [MaxLength(7)]
        public string ShortUrl { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
