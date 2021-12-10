using System;
using System.ComponentModel.DataAnnotations;

namespace ShortURL.Models
{
    public class UrlDto
    {
        [Required(ErrorMessage ="Please enter a URL")]
        [MaxLength(2048)]
        [RegularExpression(@"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+(:[0-9]+)?|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)",
            ErrorMessage ="Invalid URL")]
        public string LongUrl { get; set; }
        public string ShortUrlWithDomain { get; set; }
    }
}
