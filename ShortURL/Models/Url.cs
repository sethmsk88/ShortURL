using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShortURL.Models
{
    [Index(nameof(ShortUrl), IsUnique = true)]
    public class Url
    {
        [Key]
        [Required]
        [MaxLength(7)]
        public string ShortUrl { get; set; }
        [Required]
        [MaxLength(2048)]
        public string LongUrl { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
