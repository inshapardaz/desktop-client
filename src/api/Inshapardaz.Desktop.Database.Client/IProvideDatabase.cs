using System.IO;
using Inshapardaz.Data;
using Inshapardaz.Desktop.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Inshapardaz.Desktop.Database.Client
{
    public interface IProvideDatabase
    {
        IDictionaryDatabase GetDatabaseForDictionary(int dictionaryId);
    }

    public class DatabaseProvider : IProvideDatabase
    {
        private readonly IProvideUserSettings _settings;

        public DatabaseProvider(IProvideUserSettings settings)
        {
            _settings = settings;
        }

        public IDictionaryDatabase GetDatabaseForDictionary(int dictionaryId)
        {
            var databasePath = Path.Combine(_settings.DictionariesFolder, $"{dictionaryId}.dat");
            var connectionString = new SqliteConnectionStringBuilder { DataSource = databasePath };
            var optionsBuilder = new DbContextOptionsBuilder<DictionaryDatabase>();
            optionsBuilder.UseSqlite(connectionString.ConnectionString);
            return new DictionaryDatabase(optionsBuilder.Options);
        }
    }
}