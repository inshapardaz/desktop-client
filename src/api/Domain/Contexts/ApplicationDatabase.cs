using Inshapardaz.Desktop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inshapardaz.Desktop.Domain.Contexts
{
    public class ApplicationDatabase : DbContext, IApplicationDatabase
    {
        public ApplicationDatabase(DbContextOptions options)
            : base(options)
        {
            
        }
        public DbSet<Setting> Setting { get; set; }

        public DbSet<Dictionary> Dictionaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var sqliteOptionsExtension = optionsBuilder.Options.FindExtension<SqliteOptionsExtension>();
            //string connectionString = "Data Source=inshapardaz.dat";
            //if (sqliteOptionsExtension != null)
            //{
            //    connectionString = sqliteOptionsExtension.ConnectionString;
            //}

            //optionsBuilder.UseSqlite(connectionString);
        }
    }
}