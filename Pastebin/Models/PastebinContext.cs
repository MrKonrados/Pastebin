using System.Data.Entity;

namespace Pastebin.Models
{
    public class PastebinContext : DbContext
    {
        public PastebinContext() : base("PastebinDB")
        {

        }

        public DbSet<Paste> Pastes { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}