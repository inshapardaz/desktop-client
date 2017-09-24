using System.IO;
using Inshapardaz.Data;
using Inshapardaz.Desktop.Common;
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

        public static DictionaryDatabase ConnectToId(IProvideUserSettings setting, int dictionaryId)
        {
            var dictionaryFile = Path.Combine(setting.DictionariesFolder, $"{dictionaryId}.dat");
            return Connect(dictionaryFile);
        }
    }
}
