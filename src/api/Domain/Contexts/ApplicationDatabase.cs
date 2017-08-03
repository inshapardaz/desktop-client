using Inshapardaz.Desktop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inshapardaz.Desktop.Domain.Contexts
{
    public class ApplicationDatabase : DbContext, IApplicationDatabase
    {
        public DbSet<Setting> Setting { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=inshapardaz.dat");
        }
    }
}