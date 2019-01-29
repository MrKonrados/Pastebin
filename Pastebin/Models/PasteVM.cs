using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Pastebin.Models
{
    public class PasteVM
    {
        public int PasteId { get; set; }
        public int LanguageId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public IEnumerable<SelectListItem> Languages { get; set; }
    }
}