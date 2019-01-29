using System.ComponentModel.DataAnnotations;

namespace Pastebin.Models
{
    public class Paste
    {
        public int PasteId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        [MaxLength(12)]
        public string URI { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}