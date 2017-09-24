using Inshapardaz.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Inshapardaz.Desktop.Domain
{
    public static class DatabaseConnection
    {
        public static DictionaryDatabase Connect(string databasePath)
        {
            var connectionString = new SqliteConnectionStringBuilder { DataSource = databasePath };
            var optionsBuilder = new DbContextOptionsBuilder<DictionaryDatabase>();
            optionsBuilder.UseSqlite(connectionString.ConnectionString);
            return new DictionaryDatabase(optionsBuilder.Options);
        }
    }
}
